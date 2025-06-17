using System;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using POO_Buscarr.database;

namespace POO_Buscarr.controller
{
    public class PasswordRecoveryController
    {
        private readonly Database _database;
        private const int CodeExpirationMinutes = 30;

        // Configurações de email
        private const string EmailRemetente = "buscarteamacelera@gmail.com";
        private const string SenhaEmail = "ipba ymjg ybgf ujzq"; 

        public PasswordRecoveryController(Database database)
        {
            _database = database;
        }

        public async Task<bool> RequestPasswordRecovery(string email)
        {
            MySqlTransaction transaction = null;

            try
            {
                _database.OpenConnection();
                transaction = _database.GetConnection().BeginTransaction();

                if (!EmailExistsInUsuarios(email))
                {
                    transaction.Commit();
                    return true;
                }

                string recoveryCode = GenerateRecoveryCode();

                string insertSql = @"INSERT INTO password_recovery 
                                    (email, code, expiration_date) 
                                    VALUES (@email, @code, @expiration)";

                using (var cmd = new MySqlCommand(insertSql, _database.GetConnection(), transaction))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@code", recoveryCode);
                    cmd.Parameters.AddWithValue("@expiration", DateTime.Now.AddMinutes(CodeExpirationMinutes));
                    cmd.ExecuteNonQuery();
                }

                await SendRecoveryEmail(email, recoveryCode);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine($"Erro na recuperação: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        private bool EmailExistsInUsuarios(string email)
        {
            string sql = "SELECT COUNT(1) FROM usuarios WHERE email = @email";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool ValidateRecoveryCode(string email, string code)
        {
            try
            {
                _database.OpenConnection();

                string sql = @"SELECT COUNT(1) FROM password_recovery 
                               WHERE email = @email AND code = @code 
                               AND expiration_date > NOW() AND used = 0";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@code", code);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao validar código: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool UpdatePasswordWithRecovery(string email, string newPassword)
        {
            MySqlTransaction transaction = null;

            try
            {
                _database.OpenConnection();
                transaction = _database.GetConnection().BeginTransaction();

                if (!EmailExistsInUsuarios(email))
                    throw new InvalidOperationException("Email não encontrado.");

                string updateSql = "UPDATE usuarios SET senha = @senha WHERE email = @email";

                using (var cmd = new MySqlCommand(updateSql, _database.GetConnection(), transaction))
                {
                    cmd.Parameters.AddWithValue("@senha", BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword, 13));
                    cmd.Parameters.AddWithValue("@email", email);

                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("Falha ao atualizar senha.");
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine($"Erro ao atualizar senha: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public void MarkCodeAsUsed(string email, string code)
        {
            try
            {
                _database.OpenConnection();

                string sql = "UPDATE password_recovery SET used = 1 WHERE email = @email AND code = @code";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao marcar código como usado: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        private string GenerateRecoveryCode()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[4];
                rng.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").Substring(0, 6).ToUpper();
            }
        }

        private async Task SendRecoveryEmail(string email, string code)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(EmailRemetente, SenhaEmail),
                    EnableSsl = true,
                    Timeout = 30000
                })
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(EmailRemetente),
                        Subject = "Código de Recuperação - Buscarr",
                        Body = $@"
                        <h2>Recuperação de Senha</h2>
                        <p>Seu código é: <strong>{code}</strong></p>
                        <p>Este código expira em {CodeExpirationMinutes} minutos.</p>",
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(email);
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine($"Email enviado para: {email}");
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Erro SMTP: {ex.StatusCode} - {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral ao enviar email: {ex}");
                throw;
            }
        }
    }
}

using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using POO_Buscarr.database;
using POO_Buscarr.model;

using System;
using System.Collections.Generic;

namespace POO_Buscarr.controller
{

    public class UserController
    {
        private readonly Database _database;

        public UserController(Database database)
        {
            _database = database;
        }

        public int AddUser(string nome, string email, string senha, string cpf)
        {
            try
            {
                _database.OpenConnection();

                // Validação de e-mail
                if (!Email_controller.IsValid(email))
                {
                    Console.WriteLine("Email inválido!");
                    return -1;
                }

                // Verifica se o e-mail já está em uso
                if (EmailExists(email))
                {
                    Console.WriteLine("Email já está em uso!");
                    return -1;
                }

                // Validação de senha
                if (!Password_controller.Verify(senha))
                {
                    Console.WriteLine("Senha inválida!");
                    return -1;
                }

                // Validação de CPF
                if (!CPFController.ValidateCpf(cpf))
                {
                    Console.WriteLine("CPF inválido!");
                    return -1;
                }

                // Criptografa a senha
                string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(senha, 13);

                // Comando SQL de inserção
                string sql = "INSERT INTO usuarios (nome, email, senha, cpf) VALUES (@nome, @email, @senha, @cpf)";
                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", hashedPassword);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    cmd.ExecuteNonQuery();
                    return (int)cmd.LastInsertedId; // Retorna o ID do usuário recém-inserido
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
                return -1;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool AddAdminUser(int userId, string cnpj)
        {
            try
            {
                _database.OpenConnection();

                if (!CNPJController.ValidateCnpj(cnpj) || !CNPJController.IsNotKnownInvalid(cnpj))
                {
                    Console.WriteLine("CNPJ inválido!");
                    return false;
                }

                string insertAdminSql = "INSERT INTO admin (id, cnpj) VALUES (@id, @cnpj)";
                using (var cmdAdmin = new MySqlCommand(insertAdminSql, _database.GetConnection()))
                {
                    cmdAdmin.Parameters.AddWithValue("@id", userId);
                    cmdAdmin.Parameters.AddWithValue("@cnpj", cnpj);

                    int affectedRows = cmdAdmin.ExecuteNonQuery();
                    UpdateUserType(userId, 1);

                    return affectedRows > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao adicionar admin: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public void UpdateUserType(int userId, short userType)
        {
            try
            {
                _database.OpenConnection();

                string sql = "INSERT INTO usuarios (tipoUser) VALUES (@tipoUser) WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@tipoUser", userType);
                    cmd.Parameters.AddWithValue("@id", userId);

                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao alterar o tipo do usuário: {ex.Message}");
            }

            finally
            {
                _database.CloseConnection();
            }
        }

        public bool AddDriverUser(int userId, string cnh)
        {
            try
            {
                _database.OpenConnection();

                if (!CNHController.ValidateCnh(cnh))
                {
                    Console.WriteLine("CNH inválida!");
                    return false;
                }

                string sql = "INSERT INTO motorista (id, cnh) VALUES (@id, @cnh)";
                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.Parameters.AddWithValue("@cnh", cnh);

                    int affectedRows = cmd.ExecuteNonQuery();
                    UpdateUserType(userId, 2);

                    return affectedRows > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao adicionar motorista: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }


        private bool EmailExists(string email)
        {
            try
            {
                if (_database.GetConnection().State != System.Data.ConnectionState.Open)
                {
                    _database.OpenConnection();
                }
                string sql = "SELECT COUNT(1) FROM usuarios WHERE email = @email";
                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            finally
            {
                // Não fecha a conexão para não interferir com operações externas
            }
        }

        private bool AdminEmailExists(string email)
        {
            try
            {
                if (_database.GetConnection().State != System.Data.ConnectionState.Open)
                {
                    _database.OpenConnection();
                }

                string sql = "SELECT COUNT(1) FROM admin WHERE email = @email";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            finally
            {
                // Não fecha a conexão para não interferir com operações externas
            }
        }

        private bool DriverEmailExists(string email)
        {
            try
            {
                if (_database.GetConnection().State != System.Data.ConnectionState.Open)
                {
                    _database.OpenConnection();
                }

                string sql = "SELECT COUNT(1) FROM motorista WHERE email = @email";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            finally
            {
                // Não fecha a conexão para não interferir com operações externas
            }
        }

        public List<User> ListUsers()
        {
            var users = new List<User>();

            try
            {
                _database.OpenConnection();
                string sql = "SELECT id, nome, email FROM usuarios";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("nome"),
                            Email = reader.GetString("email")
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao listar usuários: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }

            return users;
        }

        public User GetUserById(int id)
        {
            try
            {
                _database.OpenConnection();
                string sql = "SELECT id, nome, email FROM usuarios WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("nome"),
                                Email = reader.GetString("email")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao buscar usuário: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }

            return null;
        }

        public bool UpdateAdminUser(int id, string newName, string newEmail)
        {
            try
            {
                _database.OpenConnection();
                string sql = "UPDATE admin SET nome = @nome, email = @email WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nome", newName);
                    cmd.Parameters.AddWithValue("@email", newEmail);
                    cmd.Parameters.AddWithValue("@id", id);

                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool UpdateDriverUser(int id, string newName, string newEmail)
        {
            try
            {
                _database.OpenConnection();
                string sql = "UPDATE motorista SET nome = @nome, email = @email WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nome", newName);
                    cmd.Parameters.AddWithValue("@email", newEmail);
                    cmd.Parameters.AddWithValue("@id", id);

                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool DeleteAdminUser(int id)
        {
            try
            {
                _database.OpenConnection();
                string sql = "DELETE FROM admin WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool DeleteDriverUser(int id)
        {
            try
            {
                _database.OpenConnection();
                string sql = "DELETE FROM motorista WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }
    }
}
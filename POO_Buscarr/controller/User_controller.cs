using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using POO_Buscarr.database;
using POO_Buscarr.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{

    public class UserController
    {
        private readonly Database _database;

        public UserController(Database database)
        {
            _database = database;
        }

        public bool AddAdminUser(string name, string email, string password, string cnpj, string cpf)
        {
            try
            {
                _database.OpenConnection();

                // Validação de email
                if (!POO_Buscarr.controller.Email_controller.IsValid(email))
                {
                    Console.WriteLine("Email inválido!");
                    return false;
                }

                // Verifica email duplicado
                if (AdminEmailExists(email))
                {
                    Console.WriteLine("Email já está em uso!");
                    return false;
                }

                // Validação de CNPJ
                if (!CNPJController.ValidateCnpj(cnpj) || !CNPJController.IsNotKnownInvalid(cnpj))
                {
                    Console.WriteLine("CNPJ inválido!");
                    return false;
                }

                // Validação de CPF
                if (!CPFController.ValidateCpf(cpf))
                {
                    Console.WriteLine("CPF inválido!");
                    return false;
                }

                if (!POO_Buscarr.controller.Password_controller.IsValid(password))
                {
                    Console.WriteLine("Senha inválida!");
                    return false;
                }

                string sql = @"INSERT INTO admin (name, email, password, cnpj, cpf) 
                         VALUES (@name, @email, @password, @cnpj, @cpf)";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@cnpj", cnpj);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao adicionar usuário admin: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        public bool AddDriverUser(string name, string email, string password, string cnh, string cpf)
        {
            try
            {
                _database.OpenConnection();

                // Validações básicas
                if (!POO_Buscarr.controller.Email_controller.IsValid(email))
                {
                    Console.WriteLine("Email inválido!");
                    return false;
                }

                if (DriverEmailExists(email))
                {
                    Console.WriteLine("Email já está em uso!");
                    return false;
                }

                if (!CPFController.ValidateCpf(cpf))
                {
                    Console.WriteLine("CPF inválido!");
                    return false;
                }

                if (!CNHController.ValidateCnh(cnh))
                {
                    Console.WriteLine("CNH inválida!");
                    return false;
                }

                string sql = @"INSERT INTO motorista (name, email, password, cnh, cpf) 
                         VALUES (@name, @email, @password, @cnh, @cpf)";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@cnh", cnh);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    int affectedRows = cmd.ExecuteNonQuery();
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
                string sql = "SELECT id, name, email FROM users";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
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
                string sql = "SELECT id, name, email FROM users WHERE id = @id";

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
                                Name = reader.GetString("name"),
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
                string sql = "UPDATE admin SET name = @name, email = @email WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
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
                string sql = "UPDATE motorista SET name = @name, email = @email WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
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

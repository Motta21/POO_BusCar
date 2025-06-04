using POO_Buscarr.database;
using POO_Buscarr.model;
using POO_Buscarr.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{
    public class Student_controller
    {
        private readonly Database _database;
        public Student_controller(Database database)
        {
            _database = database;
        }

        public bool AddStudent(string name, int age, string responsible, string cpfResponsible)
        {
            _database.OpenConnection();

            if (!CPFController.ValidateCpf(cpfResponsible)) return false;

            try
            {
                string query = "INSERT INTO aluno (nome_Aluno, idade, nome_Responsavel, cpf_Responsavel) VALUES (@name, @age, @responsible, @cpfResponsible)";

                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@responsible", responsible);
                    command.Parameters.AddWithValue("@cpfResponsible", cpfResponsible);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Nenhum aluno foi adicionado.");
                        return false;
                    }
                }
                Console.WriteLine($"Aluno {name} adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar aluno: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
            return true;
        }

        public bool DeleteStudent(string name)
        {
            _database.OpenConnection();

            try
            {
                string query = "DELETE FROM aluno WHERE nome_Aluno = @name";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@name", name);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Nenhum aluno foi encontrado com esse nome.");
                        return false;
                    }
                }
                Console.WriteLine($"Aluno {name} deletado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar aluno: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
            return true;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            _database.OpenConnection();

            try
            {
                string query = "SELECT * FROM aluno";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["nome_Aluno"].ToString();
                            int age = Convert.ToInt32(reader["idade"]);
                            string responsible = reader["nome_Responsavel"].ToString();
                            string cpfResponsible = reader["cpf_Responsavel"].ToString();
                            Student student = new Student(name, age.ToString(), responsible, cpfResponsible);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar alunos: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }

            return students;
        }

        public Student GetStudentByName(string name)
        {
            _database.OpenConnection();

            try
            {
                string query = "SELECT * FROM aluno WHERE nome_Aluno = @name";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int age = Convert.ToInt32(reader["idade"]);
                            string responsible = reader["nome_Responsavel"].ToString();
                            string cpfResponsible = reader["cpf_Responsavel"].ToString();
                            return new Student(name, age.ToString(), responsible, cpfResponsible);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar aluno: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }

            return null;
        }

        public bool UpdateStudent(string name, int age, string responsible, string cpfResponsible)
        {
            _database.OpenConnection();
            try
            {
                string query = "UPDATE aluno SET idade = @age, nome_Responsavel = @responsible, cpf_Responsavel = @cpfResponsible WHERE nome_Aluno = @name";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@responsible", responsible);
                    command.Parameters.AddWithValue("@cpfResponsible", cpfResponsible);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Nenhum aluno foi encontrado com esse nome.");
                        return false;
                    }
                }
                Console.WriteLine($"Aluno {name} atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar aluno: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
            return true;
        }


    }
}
using MySql.Data.MySqlClient;
using POO_Buscarr.model;
using System;
using System.Collections.Generic;

namespace POO_Buscarr.controller
{
    public class AlunoController
    {
        private readonly string _connectionString;

        public AlunoController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AdicionarAluno(Aluno aluno)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO aluno 
                                   (nome_Aluno, idade, endereco, escola, 
                                    nome_Responsavel, cpf_Responsavel, telefone_Responsavel) 
                                   VALUES (@Nome, @Idade, @Endereco, @Escola, 
                                           @NomeResponsavel, @CpfResponsavel, @TelefoneResponsavel)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", aluno.Nome);
                    command.Parameters.AddWithValue("@Idade", aluno.Idade);
                    command.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                    command.Parameters.AddWithValue("@Escola", aluno.Escola);
                    command.Parameters.AddWithValue("@NomeResponsavel", aluno.NomeResponsavel);
                    command.Parameters.AddWithValue("@CpfResponsavel", aluno.CpfResponsavel);
                    command.Parameters.AddWithValue("@TelefoneResponsavel", aluno.TelefoneResponsavel);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar aluno: " + ex.Message);
            }
        }

        public bool AtualizarAluno(Aluno aluno)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE aluno SET 
                                   nome_Aluno = @Nome, 
                                   idade = @Idade, 
                                   endereco = @Endereco, 
                                   escola = @Escola, 
                                   nome_Responsavel = @NomeResponsavel, 
                                   cpf_Responsavel = @CpfResponsavel, 
                                   telefone_Responsavel = @TelefoneResponsavel 
                                   WHERE idAluno = @idAluno";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdAluno", aluno.Id);
                    command.Parameters.AddWithValue("@Nome", aluno.Nome);
                    command.Parameters.AddWithValue("@Idade", aluno.Idade);
                    command.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                    command.Parameters.AddWithValue("@Escola", aluno.Escola);
                    command.Parameters.AddWithValue("@NomeResponsavel", aluno.NomeResponsavel);
                    command.Parameters.AddWithValue("@CpfResponsavel", aluno.CpfResponsavel);
                    command.Parameters.AddWithValue("@TelefoneResponsavel", aluno.TelefoneResponsavel);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno: " + ex.Message);
            }
        }

        public List<Aluno> ListarAlunos(string filtro = "")
        {
            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT idAluno, nome_Aluno, idade, endereco, escola, 
                                   nome_Responsavel, cpf_Responsavel, telefone_Responsavel 
                                   FROM aluno";

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query += " WHERE nome_Aluno LIKE @Filtro";
                    }

                    MySqlCommand command = new MySqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        command.Parameters.AddWithValue("@Filtro", $"%{filtro}%");
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alunos.Add(new Aluno
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome_Aluno"].ToString(),
                                Idade = Convert.ToInt32(reader["idade"]),
                                Endereco = reader["endereco"].ToString(),
                                Escola = reader["escola"].ToString(),
                                NomeResponsavel = reader["nome_Responsavel"].ToString(),
                                CpfResponsavel = reader["cpf_Responsavel"].ToString(),
                                TelefoneResponsavel = reader["telefone_Responsavel"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar alunos: " + ex.Message);
            }

            return alunos;
        }

        public Aluno ObterAlunoPorId(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT idAluno, nome_Aluno, idade, endereco, escola, 
                                   nome_Responsavel, cpf_Responsavel, telefone_Responsavel 
                                   FROM aluno WHERE idAluno = @IdAluno";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdAluno", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Aluno
                            {
                                Id = Convert.ToInt32(reader["idAluno"]),
                                Nome = reader["nome_Aluno"].ToString(),
                                Idade = Convert.ToInt32(reader["idade"]),
                                Endereco = reader["endereco"].ToString(),
                                Escola = reader["escola"].ToString(),
                                NomeResponsavel = reader["nome_Responsavel"].ToString(),
                                CpfResponsavel = reader["cpf_Responsavel"].ToString(),
                                TelefoneResponsavel = reader["telefone_Responsavel"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter aluno: " + ex.Message);
            }

            return null;
        }
    }
}
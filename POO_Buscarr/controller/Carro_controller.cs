using POO_Buscarr.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace POO_Buscarr.controller
{
    public class CarroController
    {
        private readonly string _connectionString;

        public CarroController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Carro> ListarCarros()
        {
            var lista = new List<Carro>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM carro", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Carro
                    {
                        Id = (int)reader["id"],
                        Modelo = reader["modelo"].ToString(),
                        Placa = reader["placa"].ToString(),
                        Renavam = reader["renavam"].ToString(),
                        Status = reader["status"].ToString()
                    });
                }
            }

            return lista;
        }

        public void AdicionarCarro(Carro carro)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO carro (modelo, placa, renavam, status) VALUES (@modelo, @placa, @renavam, @status)", conn);
                cmd.Parameters.AddWithValue("@modelo", carro.Modelo);
                cmd.Parameters.AddWithValue("@placa", carro.Placa);
                cmd.Parameters.AddWithValue("@renavam", carro.Renavam);
                cmd.Parameters.AddWithValue("@status", carro.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarCarro(Carro carro)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE carro SET modelo = @modelo, placa = @placa, renavam = @renavam, status = @status WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", carro.Id);
                cmd.Parameters.AddWithValue("@modelo", carro.Modelo);
                cmd.Parameters.AddWithValue("@placa", carro.Placa);
                cmd.Parameters.AddWithValue("@renavam", carro.Renavam);
                cmd.Parameters.AddWithValue("@status", carro.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletarCarro(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM carro WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using POO_Buscarr.database;
using POO_Buscarr.model;

namespace POO_Buscarr.controller
{
    internal class Car_controller
    {
        private readonly Database database;

        public Car_controller()
        {
            database = new Database();
        }

        public void AddCar(string model, string brand, string plate, string renavan, string situation)
        {
            Car car = new Car(model, brand, plate, renavan, situation);
            
            if (!database.OpenConnection()) return;

            string query = "INSERT INTO carro (modelo, marca, placa, renavan, status) VALUES (@model, @brand, @plate, @renavan, @status)";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@plate", plate);
                cmd.Parameters.AddWithValue("@renavan", renavan);
                cmd.Parameters.AddWithValue("@status", situation);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Carro adicionado com sucesso.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao adicionar carro: " + ex.Message);
                }
                finally
                {
                    database.CloseConnection();
                }
            }
        }

        public void UpdateCar(string model, string brand, string plate, string renavan, string situation)
        {
            if (!database.OpenConnection()) return;

            string query = "UPDATE carro SET modelo = @model, marca = @brand, placa = @plate, status = @situation WHERE renavan = @renavan";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@plate", plate);
                cmd.Parameters.AddWithValue("@situation", situation);
                cmd.Parameters.AddWithValue("@renavan", renavan);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Carro atualizado com sucesso.");
                }

                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao atualizar carro: " + ex.Message);
                }

                finally
                {
                    database.CloseConnection();
                }
            }
        }

        public void DeleteCar(string renavan)
        {
            if (!database.OpenConnection()) return;

            string query = "DELETE FROM carro WHERE renavan = @renavan";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@renavan", renavan);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Carro deletado com sucesso.");
                }

                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao deletar carro: " + ex.Message);
                }

                finally
                {
                    database.CloseConnection();
                }
            }
        }

        public void ListCars()
        {
            if (!database.OpenConnection()) return;

            string query = "SELECT * FROM carro";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Modelo: {reader["modelo"]}, Marca: {reader["marca"]}, Renavan: {reader["renavan"]}, Placa: {reader["placa"]}, Situação: {reader["status"]}");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao listar carros: " + ex.Message);
                }

                finally
                {
                    database.CloseConnection();
                }
            }
        }

        public void SearchCar(string renavan)
        {
            if (!database.OpenConnection()) return;

            string query = "SELECT * FROM carro WHERE renavan = @renavan";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@renavan", renavan);
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Modelo: {reader["model"]}, Marca: {reader["brand"]}, Renavan: {reader["renavan"]}, Placa: {reader["plate"]}, Situação: {reader["situation"]}");
                        }
                        else
                        {
                            Console.WriteLine("Carro não encontrado.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao buscar carro: " + ex.Message);
                }
                finally
                {
                    database.CloseConnection();
                }
            }
        }
    }
}

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

        public void AddCar(string model, string brand, string renavan, string plate, string situation)
        {
            Car car = new Car(model, brand, renavan, plate, situation);
            database.OpenConnection();
            
            string query = "INSERT INTO cars (model, brand, renavan, plate, situation) VALUES (@model, @brand, @renavan, @plate, @situation)";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@renavan", renavan);
                cmd.Parameters.AddWithValue("@plate", plate);
                cmd.Parameters.AddWithValue("@situation", situation);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Carro adicionado com sucesso.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao adicionar carro: " + ex.Message);
                }
            }

            database.CloseConnection();
        }

        public void UpdateCar(string renavan, string model, string brand, string plate, string situation)
        {
            database.OpenConnection();
            
            string query = "UPDATE cars SET model = @model, brand = @brand, plate = @plate, situation = @situation WHERE renavan = @renavan";
            
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
            }
            database.CloseConnection();
        }

        public void DeleteCar(string renavan)
        {
            database.OpenConnection();
            
            string query = "DELETE FROM cars WHERE renavan = @renavan";
            
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
            }
            database.CloseConnection();
        }

        public void ListCars()
        {
            database.OpenConnection();
            
            string query = "SELECT * FROM cars";
            
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Modelo: {reader["model"]}, Marca: {reader["brand"]}, Renavan: {reader["renavan"]}, Placa: {reader["plate"]}, Situação: {reader["situation"]}");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao listar carros: " + ex.Message);
                }
            }
            database.CloseConnection();
        }

        public void SearchCar(string renavan)
        {
            database.OpenConnection();
            
            string query = "SELECT * FROM cars WHERE renavan = @renavan";
            
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
            }
            database.CloseConnection();
        }
    }
}

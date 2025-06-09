using POO_Buscarr.database;
using POO_Buscarr.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{
    public class Car_controller
    {
        private readonly Database _database;

        public Car_controller(Database database)
        {
            _database = database;
        }

        public bool AddCar(string model, string plate, string renavam)
        {
            var car = new Car(model, plate, renavam, CarSituation.Available);
            
            if (!validateRenavam(renavam))
            {   
                Console.WriteLine("RENAVAM inválido");
                return false;
            }

            _database.OpenConnection();

            try
            {
                string query = "INSERT INTO carro (modelo, placa, renavam, status) VALUES (@model, @plate, @renavam, @situation)";

                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@plate", plate);
                    command.Parameters.AddWithValue("@renavam", renavam);
                    command.Parameters.AddWithValue("@situation", CarSituation.Available.ToString());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Nenhum carro foi adicionado.");
                        return false;
                    }
                }
                Console.WriteLine($"Carro {model} adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar carro: {ex.Message}");
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }

            return true;
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            _database.OpenConnection();
            try
            {
                string query = "SELECT * FROM carro";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var car = new Car(
                                reader["modelo"].ToString(),
                                reader["placa"].ToString(),
                                reader["renavam"].ToString(),
                                (CarSituation)Enum.Parse(typeof(CarSituation), reader["status"].ToString())
                            );
                            cars.Add(car);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter carros: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }
            return cars;
        }

        public Car GetCarByPlate(string plate)
        {
            _database.OpenConnection();
            try
            {
                string query = "SELECT * FROM carro WHERE placa = @plate";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@plate", plate);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Car(
                                reader["modelo"].ToString(),
                                reader["placa"].ToString(),
                                reader["renavam"].ToString(),
                                (CarSituation)Enum.Parse(typeof(CarSituation), reader["status"].ToString())
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter carro: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }
            return null;
        }

        public bool UpdateCarSituation(string plate, CarSituation situation)
        {
            _database.OpenConnection();
            try
            {
                string query = "UPDATE carro SET status = @situation WHERE placa = @plate";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@situation", situation.ToString());
                    command.Parameters.AddWithValue("@plate", plate);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Situação do carro com placa {plate} atualizada para {situation}.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar situação do carro: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }
            return false;
        }

        public bool DeleteCar(string plate)
        {
            _database.OpenConnection();
            try
            {
                string query = "DELETE FROM carro WHERE placa = @plate";
                using (var command = _database.GetConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@plate", plate);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Carro com placa {plate} deletado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar carro: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection();
            }
            return false;
        }


        public static bool validateRenavam(string renavam)
        {
            if (string.IsNullOrEmpty(renavam)) return false;

            // Remove caracteres não numéricos
            string numericRenavam = Regex.Replace(renavam, "[^0-9]", "");

            // O RENAVAM deve ter 11 dígitos
            if (numericRenavam.Length != 11) return false;

            // Verifica se todos os números são iguais (exemplo: "11111111111")
            if (numericRenavam.Distinct().Count() == 1) return false;

            // Sequência de multiplicação para cálculo do dígito verificador
            int[] sequence = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] digits = numericRenavam.Select(c => int.Parse(c.ToString())).ToArray();

            // Calcula o dígito verificador
            int sum = digits.Take(10).Select((digit, index) => digit * sequence[index]).Sum();
            int remainder = (sum * 10) % 11;
            int checkDigit = remainder == 10 ? 0 : remainder;

            // Compara com o último dígito do RENAVAM
            return checkDigit == digits[10];
        }
    }
}
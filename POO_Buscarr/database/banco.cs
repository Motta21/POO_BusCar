using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.database
{
    public class Database
    {
        private string connectionString = "server=localhost;database=buscard;uid=root;pwd=;";
        private MySqlConnection cnn;

        public Database()
        {
            cnn = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return cnn;
        }

        public bool OpenConnection()
        {
            try
            {
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                    Console.WriteLine("Conexão aberta com sucesso.");
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
                return false;
            }
        }


        public void CloseConnection()
        {
            try
            {
                cnn.Close();
                Console.WriteLine("Conexão fechada.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
            }
        }
    }
}

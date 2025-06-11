using MySql.Data.MySqlClient;
using System;

namespace POO_Buscarr.database
{
    public class Database : IDisposable
    {
        private readonly string connectionString = "server=localhost;database=buscard;uid=root;pwd=;";
        private MySqlConnection cnn;
        private bool _disposed = false;

        public Database()
        {
            cnn = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            if (_disposed)
                throw new ObjectDisposedException("Database", "O objeto Database já foi descartado");

            return cnn;
        }

        public bool OpenConnection()
        {
            if (_disposed)
                throw new ObjectDisposedException("Database", "O objeto Database já foi descartado");

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
            if (_disposed)
                return;

            try
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                    Console.WriteLine("Conexão fechada.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
            }
        }

        // Implementação do IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Libera recursos gerenciados
                    CloseConnection(); // Fecha a conexão se estiver aberta
                    cnn?.Dispose();   // Libera os recursos da conexão
                }

                // Libera recursos não gerenciados (se houver)

                _disposed = true;
            }
        }

        // Destrutor (para limpeza adicional caso necessário)
        ~Database()
        {
            Dispose(false);
        }
    }
}
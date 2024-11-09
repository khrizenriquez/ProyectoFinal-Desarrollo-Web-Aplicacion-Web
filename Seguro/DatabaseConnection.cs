using System;
using System.Data.SqlClient;

namespace Seguro
{
    public static class DatabaseConnection
    {
        private static SqlConnection _connection;
        public static string ConnectionStatus { get; private set; } = "0";

        public static SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection("Server=192.168.1.52,1433;Database=SeguroMedicoDesarrolloWeb;User Id=desarrolloweb;Password=DesarolloWeb2024;Encrypt=True;TrustServerCertificate=True;");
            }
            return _connection;
        }

        public static void OpenConnection()
        {
            if (_connection == null)
            {
                _connection = GetConnection();
            }

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
                ConnectionStatus = "1";
            }
        }

        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                ConnectionStatus = "0";
            }
        }
    }
}

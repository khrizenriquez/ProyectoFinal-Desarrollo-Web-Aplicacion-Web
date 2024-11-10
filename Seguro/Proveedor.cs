using System;
using System.Data.SqlClient;

namespace Seguro.Models
{
    public class Proveedor
    {
        public string Nit { get; set; }
        public string RazonSocial { get; set; }

        /*public void InsertarProveedor()
        {
            DatabaseConnection.OpenConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores (Nit, RazonSocial) VALUES (@Nit, " +
                "@RazonSocial)", DatabaseConnection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Nit", Nit);
                cmd.Parameters.AddWithValue("@RazonSocial", RazonSocial);
                cmd.ExecuteNonQuery();
            }
            DatabaseConnection.CloseConnection();
        }*/

    }
}

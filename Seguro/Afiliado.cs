using System;
using System.Data.SqlClient;

namespace Seguro
{
    public class Afiliado
    {
        public int CodigoPaciente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaInicioCobertura { get; set; }
        public decimal MontoCobertura { get; set; }

        public void InsertarAfiliado()
        {
            DatabaseConnection.OpenConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Afiliados (CodigoPaciente, PrimerNombre, SegundoNombre, PrimerApellido, " +
                "SegundoApellido, FechaNacimiento, Telefono, FechaInicioCobertura, MontoCobertura) " +
                "VALUES (@CodigoPaciente, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, " +
                "@Telefono, @FechaInicioCobertura, @MontoCobertura)", DatabaseConnection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);
                cmd.Parameters.AddWithValue("@PrimerNombre", PrimerNombre);
                cmd.Parameters.AddWithValue("@SegundoNombre", SegundoNombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", SegundoApellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@FechaInicioCobertura", FechaInicioCobertura);
                cmd.Parameters.AddWithValue("@MontoCobertura", MontoCobertura);
                cmd.ExecuteNonQuery();
            }
            DatabaseConnection.CloseConnection();
        }
    }
}

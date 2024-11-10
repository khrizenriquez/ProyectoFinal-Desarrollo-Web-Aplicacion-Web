using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Seguro
{
    public partial class AfiliadoEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAutenticado"] == null || !(bool)Session["UsuarioAutenticado"])
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack && Request.QueryString["Codigo"] != null)
            {
                var codigoPaciente = Request.QueryString["Codigo"];
                CargarAfiliado(codigoPaciente);
            }
        }

        private void CargarAfiliado(string codigoPaciente)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento, Telefono, FechaInicioCobertura, MontoCobertura FROM Pacientes WHERE CodigoPaciente = @CodigoPaciente";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);

                DatabaseConnection.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCodigoPaciente.Text = codigoPaciente;
                    txtPrimerNombre.Text = reader["PrimerNombre"].ToString();
                    txtSegundoNombre.Text = reader["SegundoNombre"].ToString();
                    txtPrimerApellido.Text = reader["PrimerApellido"].ToString();
                    txtSegundoApellido.Text = reader["SegundoApellido"].ToString();
                    txtFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy-MM-dd");
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtFechaInicioCobertura.Text = Convert.ToDateTime(reader["FechaInicioCobertura"]).ToString("yyyy-MM-dd");
                    txtMontoCobertura.Text = reader["MontoCobertura"].ToString();
                }
                reader.Close();
                DatabaseConnection.CloseConnection();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query;

                if (string.IsNullOrEmpty(txtCodigoPaciente.Text))
                {
                    query = "INSERT INTO Pacientes (PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento, Telefono, FechaInicioCobertura, MontoCobertura) " +
                            "VALUES (@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Telefono, @FechaInicioCobertura, @MontoCobertura)";
                }
                else
                {
                    query = "UPDATE Pacientes SET PrimerNombre = @PrimerNombre, SegundoNombre = @SegundoNombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, FechaInicioCobertura = @FechaInicioCobertura, MontoCobertura = @MontoCobertura WHERE CodigoPaciente = @CodigoPaciente";
                }

                SqlCommand cmd = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(txtCodigoPaciente.Text))
                {
                    cmd.Parameters.AddWithValue("@CodigoPaciente", txtCodigoPaciente.Text);
                }
                cmd.Parameters.AddWithValue("@PrimerNombre", txtPrimerNombre.Text);
                cmd.Parameters.AddWithValue("@SegundoNombre", txtSegundoNombre.Text);
                cmd.Parameters.AddWithValue("@PrimerApellido", txtPrimerApellido.Text);
                cmd.Parameters.AddWithValue("@SegundoApellido", txtSegundoApellido.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(txtFechaNacimiento.Text));
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@FechaInicioCobertura", DateTime.Parse(txtFechaInicioCobertura.Text));
                cmd.Parameters.AddWithValue("@MontoCobertura", decimal.Parse(txtMontoCobertura.Text));

                DatabaseConnection.OpenConnection();
                cmd.ExecuteNonQuery();
                DatabaseConnection.CloseConnection();

                lblMensaje.Text = string.IsNullOrEmpty(txtCodigoPaciente.Text) ? "Afiliado creado exitosamente." : "Afiliado actualizado exitosamente.";
                lblMensaje.CssClass = "notification is-success";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AfiliadoList.aspx");
        }
    }
}

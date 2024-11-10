using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Seguro
{
    public partial class PagoPrima : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaPago.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigoPaciente;
            decimal monto;

            if (int.TryParse(txtCodigoPaciente.Text, out codigoPaciente) && decimal.TryParse(txtMonto.Text, out monto) && monto > 0)
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO PagosPrima (CodigoPaciente, FechaPago, MesCoberturaCancelado, Monto) " +
                                   "VALUES (@CodigoPaciente, @FechaPago, @MesCoberturaCancelado, @Monto)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);
                    cmd.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MesCoberturaCancelado", DateTime.Parse(txtMesCoberturaCancelado.Text));
                    cmd.Parameters.AddWithValue("@Monto", monto);

                    try
                    {
                        DatabaseConnection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        lblMensaje.Text = "Pago registrado exitosamente.";
                        lblMensaje.CssClass = "notification is-success";
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = $"Error al registrar el pago: {ex.Message}";
                        lblMensaje.CssClass = "notification is-danger";
                    }
                    finally
                    {
                        DatabaseConnection.CloseConnection();
                    }
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un código de paciente y un monto válido.";
                lblMensaje.CssClass = "notification is-warning";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoPrimaList.aspx");
        }
    }
}

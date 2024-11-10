using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro
{
    public partial class PagoPrima : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAutenticado"] == null || !(bool)Session["UsuarioAutenticado"])
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                txtFechaPago.Text = DateTime.Now.ToString("yyyy-MM-dd");

                ddlAnoCobertura.Items.Clear();
                int currentYear = DateTime.Now.Year;
                ddlAnoCobertura.Items.Add(new ListItem(currentYear.ToString(), currentYear.ToString()));
                ddlAnoCobertura.Items.Add(new ListItem((currentYear + 1).ToString(), (currentYear + 1).ToString()));

                ddlMesCobertura.SelectedValue = DateTime.Now.Month.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigoPaciente = int.Parse(txtCodigoPaciente.Text);
            int anoCobertura = int.Parse(ddlAnoCobertura.SelectedValue);
            int mesCobertura = int.Parse(ddlMesCobertura.SelectedValue);

            DateTime mesCoberturaCancelado = new DateTime(anoCobertura, mesCobertura, 1);

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    DatabaseConnection.OpenConnection();

                    string checkQuery = @"SELECT COUNT(*) 
                                          FROM PagosPrima 
                                          WHERE CodigoPaciente = @CodigoPaciente 
                                          AND MesCoberturaCancelado = @MesCoberturaCancelado";

                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);
                    checkCommand.Parameters.AddWithValue("@MesCoberturaCancelado", mesCoberturaCancelado);

                    int existingPayments = (int)checkCommand.ExecuteScalar();

                    if (existingPayments > 0)
                    {
                        lblMensaje.Text = $"El pago no se puede realizar debido a que ya hay un pago registrado para este paciente y mes seleccionado.";
                        lblMensaje.CssClass = "notification is-danger";
                        return;
                    }

                    string insertQuery = @"INSERT INTO PagosPrima (CodigoPaciente, FechaPago, MesCoberturaCancelado, Monto) 
                                           VALUES (@CodigoPaciente, @FechaPago, @MesCoberturaCancelado, @Monto)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);
                    insertCommand.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@MesCoberturaCancelado", mesCoberturaCancelado);
                    insertCommand.Parameters.AddWithValue("@Monto", decimal.Parse(txtMonto.Text));

                    insertCommand.ExecuteNonQuery();

                    lblMensaje.Text = "Pago registrado exitosamente.";
                    lblMensaje.CssClass = "notification is-success";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al realizar el pago: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PagoPrimaList.aspx");
        }
    }
}

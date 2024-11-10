using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro
{
    public partial class PagoPrimaList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAutenticado"] == null || !(bool)Session["UsuarioAutenticado"])
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarPagosPrima();
            }
        }

        private void CargarPagosPrima()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = @"
                        SELECT pp.IdPago, pp.CodigoPaciente, CONCAT(p.PrimerNombre, ' ', p.PrimerApellido) AS NombrePaciente, 
                               pp.FechaPago, pp.MesCoberturaCancelado, pp.Monto 
                        FROM PagosPrima pp
                        JOIN Pacientes p ON pp.CodigoPaciente = p.CodigoPaciente";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gvPagosPrima.DataSource = dt;
                        gvPagosPrima.DataBind();
                        lblMensaje.Text = string.Empty;
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron registros de pagos de prima.";
                        lblMensaje.CssClass = "notification is-warning";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al cargar los pagos de prima: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
            }
        }

        protected void btnHacerPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoPrima.aspx");
        }
    }
}

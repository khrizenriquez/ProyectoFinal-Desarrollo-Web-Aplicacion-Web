using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Seguro
{
    public partial class ProveedorEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["NIT"] != null)
            {
                var nit = Request.QueryString["NIT"];
                CargarProveedor(nit);
            }
        }

        private void CargarProveedor(string nit)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT RazonSocial FROM Proveedores WHERE NIT = @NIT";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NIT", nit);

                DatabaseConnection.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNIT.Text = nit;
                    txtRazonSocial.Text = reader["RazonSocial"].ToString();
                    txtNIT.ReadOnly = true;
                }
                reader.Close();
                DatabaseConnection.CloseConnection();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nit = txtNIT.Text.Trim();
            string razonSocial = txtRazonSocial.Text.Trim();

            if (string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(razonSocial))
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                lblMensaje.CssClass = "notification is-danger";
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                // Verificacion sobre si el NIT ya existe
                string checkQuery = "SELECT COUNT(*) FROM Proveedores WHERE NIT = @NIT";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@NIT", nit);

                DatabaseConnection.OpenConnection();
                int count = (int)checkCmd.ExecuteScalar();

                // NIT no debería existir
                if (Request.QueryString["NIT"] == null && count > 0)
                {
                    lblMensaje.Text = "El NIT ya existe. Por favor, use uno diferente.";
                    lblMensaje.CssClass = "notification is-danger";
                    DatabaseConnection.CloseConnection();
                    return;
                }
                else if (Request.QueryString["NIT"] != null && Request.QueryString["NIT"] != nit && count > 0)
                {
                    lblMensaje.Text = "El NIT ya existe en otro proveedor.";
                    lblMensaje.CssClass = "notification is-danger";
                    DatabaseConnection.CloseConnection();
                    return;
                }

                string query;
                if (Request.QueryString["NIT"] != null)
                {
                    query = "UPDATE Proveedores SET RazonSocial = @RazonSocial WHERE NIT = @NIT";
                }
                else
                {
                    query = "INSERT INTO Proveedores (NIT, RazonSocial, Status) VALUES (@NIT, @RazonSocial, 1)";
                }

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NIT", nit);
                cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);

                try
                {
                    cmd.ExecuteNonQuery();
                    lblMensaje.Text = "Proveedor guardado exitosamente.";
                    lblMensaje.CssClass = "notification is-success";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al guardar el proveedor: {ex.Message}";
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
            Response.Redirect("ProveedorList.aspx");
        }
    }
}

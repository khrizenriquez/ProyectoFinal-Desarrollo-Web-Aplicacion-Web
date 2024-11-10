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
                }
                reader.Close();
                DatabaseConnection.CloseConnection();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Proveedores SET RazonSocial = @RazonSocial WHERE NIT = @NIT";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NIT", txtNIT.Text);
                cmd.Parameters.AddWithValue("@RazonSocial", txtRazonSocial.Text);

                DatabaseConnection.OpenConnection();
                cmd.ExecuteNonQuery();
                DatabaseConnection.CloseConnection();

                lblMensaje.Text = "Proveedor actualizado exitosamente.";
                lblMensaje.CssClass = "notification is-success";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedorList.aspx");
        }
    }
}

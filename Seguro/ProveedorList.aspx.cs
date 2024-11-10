using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro
{
    public partial class ProveedorList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        DatabaseConnection.OpenConnection();
                    }

                    string query = "SELECT NIT, RazonSocial FROM Proveedores";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gvProveedores.DataSource = dt;
                        gvProveedores.DataBind();
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron proveedores.";
                        lblMensaje.CssClass = "notification is-warning";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al cargar proveedores: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string nit = e.CommandArgument.ToString();
                Response.Redirect("~/ProveedorEdit.aspx?NIT=" + nit);
            }
            else if (e.CommandName == "Eliminar")
            {
                string nit = e.CommandArgument.ToString();
                EliminarProveedor(nit);
                CargarProveedores();
            }
        }

        private void EliminarProveedor(string nit)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        DatabaseConnection.OpenConnection();
                    }

                    string query = "DELETE FROM Proveedores WHERE NIT = @NIT";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NIT", nit);
                        command.ExecuteNonQuery();
                    }

                    lblMensaje.Text = "Proveedor eliminado exitosamente.";
                    lblMensaje.CssClass = "notification is-success";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al eliminar proveedor: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

    }
}

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
                    string query = @"SELECT NIT, RazonSocial, Status, 
                                     CASE WHEN Status = 1 THEN 'Activo' ELSE 'Inactivo' END AS Status 
                                     FROM Proveedores";

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
            }
        }

        protected void gvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var nit = gvProveedores.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect($"~/ProveedorEdit.aspx?NIT={nit}");
        }

        protected void gvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var nit = gvProveedores.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    string deactivateQuery = "UPDATE Proveedores SET Status = 0 WHERE NIT = @NIT";
                    SqlCommand command = new SqlCommand(deactivateQuery, connection);
                    command.Parameters.AddWithValue("@NIT", nit);
                    DatabaseConnection.OpenConnection();
                    command.ExecuteNonQuery();

                    lblMensaje.Text = "Proveedor desactivado exitosamente.";
                    lblMensaje.CssClass = "notification is-success";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al desactivar proveedor: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
            CargarProveedores();
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActivarDesactivar")
            {
                string nit = e.CommandArgument.ToString();
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    try
                    {
                        string toggleStatusQuery = "UPDATE Proveedores SET Status = CASE WHEN Status = 1 THEN 0 ELSE 1 END WHERE NIT = @NIT";
                        SqlCommand command = new SqlCommand(toggleStatusQuery, connection);
                        command.Parameters.AddWithValue("@NIT", nit);
                        DatabaseConnection.OpenConnection();
                        command.ExecuteNonQuery();

                        lblMensaje.Text = "Estado del proveedor actualizado exitosamente.";
                        lblMensaje.CssClass = "notification is-success";
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = $"Error al actualizar el estado del proveedor: {ex.Message}";
                        lblMensaje.CssClass = "notification is-danger";
                    }
                    finally
                    {
                        DatabaseConnection.CloseConnection();
                    }
                }
                CargarProveedores();
            }
        }

        protected void btnCrearNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProveedorEdit.aspx");
        }
    }
}

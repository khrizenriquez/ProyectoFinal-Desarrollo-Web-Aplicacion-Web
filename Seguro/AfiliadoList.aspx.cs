using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro
{
    public partial class AfiliadoList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAfiliados();
            }
        }

        private void CargarAfiliados()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = @"SELECT CodigoPaciente, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, 
                                    FechaNacimiento, Telefono, FechaInicioCobertura, MontoCobertura, Status, 
                                    CASE WHEN Status = 1 THEN 'Activo' ELSE 'Inactivo' END AS Status 
                                    FROM Pacientes";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gvAfiliados.DataSource = dt;
                        gvAfiliados.DataBind();
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron afiliados.";
                        lblMensaje.CssClass = "notification is-warning";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al cargar afiliados: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
            }
        }

        protected void gvAfiliados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var codigoPaciente = gvAfiliados.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect($"~/AfiliadoEdit.aspx?Codigo={codigoPaciente}");
        }

        protected void gvAfiliados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var codigoPaciente = gvAfiliados.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    string deactivateQuery = "UPDATE Pacientes SET Status = 0 WHERE CodigoPaciente = @CodigoPaciente";
                    SqlCommand command = new SqlCommand(deactivateQuery, connection);
                    command.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);
                    DatabaseConnection.OpenConnection();
                    command.ExecuteNonQuery();

                    lblMensaje.Text = "Afiliado desactivado exitosamente.";
                    lblMensaje.CssClass = "notification is-success";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al desactivar afiliado: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
            CargarAfiliados();
        }

        protected void gvAfiliados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActivarDesactivar")
            {
                string codigoPaciente = e.CommandArgument.ToString();
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    try
                    {
                        string toggleStatusQuery = "UPDATE Pacientes SET Status = CASE WHEN Status = 1 THEN 0 ELSE 1 END WHERE CodigoPaciente = @CodigoPaciente";
                        SqlCommand command = new SqlCommand(toggleStatusQuery, connection);
                        command.Parameters.AddWithValue("@CodigoPaciente", codigoPaciente);
                        DatabaseConnection.OpenConnection();
                        command.ExecuteNonQuery();

                        lblMensaje.Text = "Estado del afiliado actualizado exitosamente.";
                        lblMensaje.CssClass = "notification is-success";
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = $"Error al actualizar el estado del afiliado: {ex.Message}";
                        lblMensaje.CssClass = "notification is-danger";
                    }
                    finally
                    {
                        DatabaseConnection.CloseConnection();
                    }
                }
                CargarAfiliados();
            }
        }

        protected void btnCrearNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AfiliadoEdit.aspx");
        }
    }
}

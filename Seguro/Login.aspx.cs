using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Seguro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificamos si la sesión ya está activa
            if (Session["UsuarioAutenticado"] != null && (bool)Session["UsuarioAutenticado"])
            {
                // Redirigimos al usuario a la página principal si ya está autenticado
                Response.Redirect("AfiliadoList.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtPassword.Text;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND ContraseñaHash = HASHBYTES('SHA2_256', @Contraseña)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        // Login exitoso: establece una sesión de usuario
                        Session["UsuarioAutenticado"] = true;
                        Response.Redirect("AfiliadoList.aspx");
                    }
                    else
                    {
                        // Mensaje de error si las credenciales no coinciden
                        lblMensaje.Text = "Hay un error con el usuario o contraseña.";
                        lblMensaje.CssClass = "notification is-danger";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al iniciar sesión: {ex.Message}";
                    lblMensaje.CssClass = "notification is-danger";
                }
            }
        }
    }
}

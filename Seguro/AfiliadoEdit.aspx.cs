using System;
using System.Web.UI;

namespace Seguro
{
    public partial class AfiliadoEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Codigo"] != null)
            {
                var codigoPaciente = Request.QueryString["Codigo"];
                CargarAfiliado(codigoPaciente);
            }
        }

        private void CargarAfiliado(string codigoPaciente)
        {
        }

        /*protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AfiliadoList.aspx");
        }*/

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Afiliado afiliado = new Afiliado
            {
                CodigoPaciente = int.Parse(txtCodigoPaciente.Text),
                PrimerNombre = txtPrimerNombre.Text,
                SegundoNombre = txtSegundoNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                SegundoApellido = txtSegundoApellido.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                Telefono = txtTelefono.Text,
                FechaInicioCobertura = DateTime.Parse(txtFechaInicioCobertura.Text),
                MontoCobertura = decimal.Parse(txtMontoCobertura.Text)
            };

            try
            {
                // Inserta o actualiza el afiliado en la base de datos.
                afiliado.InsertarAfiliado(); // Puedes adaptar este método para actualizar si es necesario.
                lblMensaje.Text = "Afiliado guardado exitosamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al guardar el afiliado: {ex.Message}";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AfiliadoList.aspx"); // Redirecciona a la lista de afiliados
        }
    }
}

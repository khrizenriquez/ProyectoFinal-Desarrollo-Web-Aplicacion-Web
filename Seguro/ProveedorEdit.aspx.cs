using System;
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
            // Lógica para cargar los datos del proveedor y asignarlos a los campos
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Guardar o actualizar datos del proveedor
            Response.Redirect("~/ProveedorList.aspx");
        }
    }
}

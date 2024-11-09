using System;
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
            // Lógica para obtener proveedores desde la base de datos
            // GridView1.DataSource = ObtenerProveedores();
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var nit = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/ProveedorEdit.aspx?NIT=" + nit);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lógica para eliminar el proveedor
            CargarProveedores();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        protected void btnNuevoProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}

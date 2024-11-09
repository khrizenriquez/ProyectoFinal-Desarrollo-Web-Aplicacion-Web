using System;
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
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var codigoPaciente = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Afiliados/AfiliadoEdit.aspx?Codigo=" + codigoPaciente);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CargarAfiliados();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarAfiliados();
        }
    }
}

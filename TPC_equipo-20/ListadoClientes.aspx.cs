using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class ListadoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaClientes"] != null)
            {
            dgvClientes.DataSource = Session["listaClientes"];
            dgvClientes.DataBind();
            }
        }
        
        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleCliente.aspx?id=" + id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrioridades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prioridades.aspx");
        }

        protected void btnEstados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estados.aspx");
        }

        protected void btnTipos_Click(object sender, EventArgs e)
        {
            Response.Redirect("TiposIncidentes.aspx");
        }
    }
}
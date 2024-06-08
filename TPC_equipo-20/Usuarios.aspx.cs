using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.EsTelefonista(Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para acceder a esta página.");
                Response.Redirect("Error.aspx");
            }
            else
            {
               Response.Redirect("Default.aspx");
            }
        }
    }
}
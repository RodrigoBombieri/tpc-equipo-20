using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!IsPostBack)
                {
                    RolNegocio rolNegocio = new RolNegocio();
                    List<Rol> listaRoles = rolNegocio.listar();

                    ddlRoles.DataSource = listaRoles;
                    ddlRoles.DataValueField = "Id";
                    ddlRoles.DataTextField = "Descripcion";
                    ddlRoles.DataBind();
                }
			}
			catch (Exception ex)
			{

				Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
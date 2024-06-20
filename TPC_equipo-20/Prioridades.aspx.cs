using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Prioridades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!IsPostBack)
                {
                    PrioridadNegocio negocio = new PrioridadNegocio();
                    Session.Add("listadoPrioridades", negocio.listar());
                    dgvPrioridades.DataSource = Session["listadoPrioridades"];
                    dgvPrioridades.DataBind();
                }
			}
			catch (Exception ex)
			{

				Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioPrioridades.aspx", false);
        }

        protected void dgvPrioridades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvPrioridades.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioPrioridades.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
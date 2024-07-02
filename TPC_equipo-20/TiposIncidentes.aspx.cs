using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class TiposIncidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoIncidenteNegocio negocio = new TipoIncidenteNegocio();
                Session.Add("listadoTipos", negocio.listar());
                dgvTipos.DataSource = Session["listadoTipos"];
                //dgvTipos.DataSource = negocio.listar();
                dgvTipos.DataBind();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioTipoIncidente.aspx");
        }

        protected void dgvTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvTipos.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioTipoIncidente.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvTipos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvTipos.DataSource = Session["listadoTipos"];
                dgvTipos.PageIndex = e.NewPageIndex;
                dgvTipos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
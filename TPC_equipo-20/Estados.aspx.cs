using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EstadoNegocio negocio = new EstadoNegocio();
                    Session.Add("listadoEstados", negocio.listar());
                    dgvEstados.DataSource = Session["listadoEstados"];
                    dgvEstados.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvEstados.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioEstado.aspx?id=" + id, false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioEstado.aspx", false);
        }
    }
}
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Incidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncidenteNegocio negocio = new IncidenteNegocio();
                //Session.Add("listadoIncidentes", negocio.listar());
                //dgvIncidentes.DataSource = Session["listadoIncidentes"];
                dgvIncidentes.DataSource = negocio.listar();
                dgvIncidentes.DataBind();
            }
        }

        protected void dgvIncidentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvIncidentes.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioIncidencia.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvIncidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvIncidentes.DataSource = Session["listaUsuarios"];
                dgvIncidentes.PageIndex = e.NewPageIndex;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioIncidencia.aspx");
        }
        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Enabled = !chkFiltroAvanzado.Checked;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                //List<Articulo> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Codigo.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower()));
                //repRepeater.DataSource = listaFiltrada;
                //repRepeater.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Igual a");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool validarFiltro()
        {
            return false;
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            txtFiltro.Enabled = true;
            lblValidarFiltro.Text = "";
            chkFiltroAvanzado.Checked = false;
            //recargar grilla
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
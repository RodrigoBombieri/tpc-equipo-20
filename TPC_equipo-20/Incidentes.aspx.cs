using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
namespace TPC_equipo_20
{
    public partial class Incidentes : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncidenteNegocio negocio = new IncidenteNegocio();
                if (Seguridad.EsTelefonista(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    Session.Add("listadoIncidentes", negocio.listar(true,usuario.Id.ToString()));
                }
                else
                {
                    Session.Add("listadoIncidentes", negocio.listar(true));
                }
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
                //dgvIncidentes.DataSource = negocio.listar();
                dgvIncidentes.DataBind();
            }
        }

        protected void dgvIncidentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvIncidentes.SelectedDataKey.Value.ToString();
                Response.Redirect("GestionIncidente.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvIncidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {          
            try
            {
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
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
            Response.Redirect("FormularioIncidente.aspx");
        }
        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Enabled = !chkFiltroAvanzado.Checked;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
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
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
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
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        private bool validarFiltro()
        {
            return false;
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                txtFiltroAvanzado.Text = "";
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                /*IncidenteNegocio negocio = new IncidenteNegocio();

                if (chkFiltroAvanzado.Checked)
                {
                    if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    {
                        dgvIncidentes.DataSource = negocio.listar(true);
                    }
                    else
                    {
                        dgvIncidentes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                    }
                }
                else
                {
                    List<Incidente> lista = (List<Incidente>)Session["listadoIncidentes"];
                    List<Incidente> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Apellido.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Email.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Dni.ToLower().Contains(txtFiltroCliente.Text.ToLower()));
                    dgvIncidentes.DataSource = listaFiltrada;
                }
                dgvIncidentes.DataBind();*/
            }

            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {
            try
            {
               /* IncidenteNegocio negocio = new IncidenteNegocio();
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    dgvIncidentes.DataSource = negocio.listar(true);
                }
                else
                {
                    dgvIncidentes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                }
                dgvIncidentes.DataBind();*/
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
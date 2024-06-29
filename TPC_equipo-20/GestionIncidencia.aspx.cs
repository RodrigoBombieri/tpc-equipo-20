using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class GestionIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNumIncidencia.Text = "Incidencia Nº ?";
            try
            {
                if (!IsPostBack)
                {
                    //PrioridadNegocio PrioridadNegocio = new PrioridadNegocio();
                    //List<Prioridad> listaPrioridades = PrioridadNegocio.listar();
                    //EstadoNegocio EstadoNegocio = new EstadoNegocio();
                    //List<Estado> listaEstados = EstadoNegocio.listar();
                    //TipoIncidenteNegocio TipoNegocio = new TipoIncidenteNegocio();
                    //List<TipoIncidente> listaTipos = TipoNegocio.listar();

                    AccionNegocio negocio = new AccionNegocio();
                    //dgvAcciones.DataSource = Session["listadoIncidentes"];
                    dgvAcciones.DataSource = negocio.listar();
                    dgvAcciones.DataBind();

                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente aux = (negocio.listar(id))[0];

                    lblNumIncidencia.Text = "Incidencia Nº " + aux.Id;

                    txtDetalle.Text = aux.Detalle;
                }
            }
            catch (Exception ex)
            {
                throw;
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvAcciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
                    PrioridadNegocio PrioridadNegocio = new PrioridadNegocio();
                    List<Prioridad> listaPrioridades = PrioridadNegocio.listar();
                    EstadoNegocio EstadoNegocio = new EstadoNegocio();
                    //List<Estado> listaEstados = EstadoNegocio.listar();
                    Session.Add("estados", EstadoNegocio.listar());
                    TipoIncidenteNegocio TipoNegocio = new TipoIncidenteNegocio();
                    List<TipoIncidente> listaTipos = TipoNegocio.listar();

                    AccionNegocio negocio = new AccionNegocio();
                    dgvAcciones.DataSource = negocio.listar();//mandar id
                    dgvAcciones.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    if (!IsPostBack)
                    {
                        IncidenteNegocio negocio = new IncidenteNegocio();
                        Incidente aux = (negocio.listar(id))[0];

                        lblNumIncidencia.Text = "Incidencia Nº " + aux.Id;
                        List<Estado> estados = Session["estados"] as List<Estado>; ;    
                        Estado estado = estados.Find(x => x.Id == aux.Estado.Id);
                        if (estado != null)
                            lblEstado.Text = estado.Nombre;
                        else
                            lblEstado.Text="ERROR";
                        //vigente-vencido-proximo
                        //lblEstado.CssClass = "badge rounded-pill text-bg-success large-badge";
                        txtDetalle.Text = aux.Detalle;
                    }
                }
                else
                {
                    Session.Add("error", "Incidencia no encontrada.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MiControl1.LabelText = "¡Has hecho clic en el botón en MiControl!";
        }
    }
}
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
    public partial class FormularioIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                if (!IsPostBack)
                {
                    PrioridadNegocio PrioridadNegocio = new PrioridadNegocio();
                    List<Prioridad> listaPrioridades = PrioridadNegocio.listar();

                    ddlPrioridad.DataSource = listaPrioridades;
                    ddlPrioridad.DataValueField = "Id";
                    ddlPrioridad.DataTextField = "Nombre";
                    ddlPrioridad.DataBind();

                    EstadoNegocio EstadoNegocio = new EstadoNegocio();
                    List<Estado> listaEstados = EstadoNegocio.listar();

                    ddlEstado.DataSource = listaEstados;
                    ddlEstado.DataValueField = "Id";
                    ddlEstado.DataTextField = "Nombre";
                    ddlEstado.DataBind();

                    TipoIncidenteNegocio TipoNegocio = new TipoIncidenteNegocio();
                    List<TipoIncidente> listaTipos = TipoNegocio.listar();

                    ddlTipo.DataSource = listaTipos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Nombre";
                    ddlTipo.DataBind();
                }

                // En caso de que se haya pasado un id por querystring, se cargan los datos del incidente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente aux = (negocio.listar(id))[0];

                    txtDetalle.Text = aux.Detalle;
                    ddlEstado.SelectedValue = aux.Estado.Id.ToString();
                    ddlPrioridad.SelectedValue = aux.Prioridad.Id.ToString();
                    ddlTipo.SelectedValue = aux.Tipo.Id.ToString();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }


        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Incidente aux = new Incidente();
                IncidenteNegocio negocio = new IncidenteNegocio();

                aux.Detalle = txtDetalle.Text;
                aux.Prioridad.Id = short.Parse(ddlPrioridad.SelectedValue);
                aux.Estado.Id = short.Parse(ddlEstado.SelectedValue);
                aux.Tipo.Id = short.Parse(ddlTipo.SelectedValue);  
                
                if (Request.QueryString["id"] != null)
                {
                    aux.Id = long.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(aux);
                }
                else
                {
                    negocio.agregar(aux);
                }

                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}

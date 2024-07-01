using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class GestionIncidente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNumIncidente.Text = "Incidente Nº ?";
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
                    ddlPrioridad.SelectedValue = "1";

                    EstadoNegocio EstadoNegocio = new EstadoNegocio();
                    //List<Estado> listaEstados = EstadoNegocio.listar();
                    Session.Add("estados", EstadoNegocio.listar());

                    TipoIncidenteNegocio TipoNegocio = new TipoIncidenteNegocio();
                    List<TipoIncidente> listaTipos = TipoNegocio.listar();
                    ddlTipo.DataSource = listaTipos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Nombre";
                    ddlTipo.DataBind();
                    ddlTipo.SelectedValue = "1";

                    TipoAccionNegocio TipoAccionNegocio = new TipoAccionNegocio();
                    List<TipoAccion> listaTiposAcciones = TipoAccionNegocio.listar();
                    ddlTipoAcciones.DataSource = listaTiposAcciones;
                    ddlTipoAcciones.DataValueField = "Id";
                    ddlTipoAcciones.DataTextField = "Nombre";
                    ddlTipoAcciones.DataBind();
                    ddlTipoAcciones.SelectedIndex = -1;
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    if (!IsPostBack)
                    {
                        IncidenteNegocio negocio = new IncidenteNegocio();
                        List<Incidente> listado = negocio.listar(id);
                        Incidente aux;
                        if (listado.Count > 0)
                        {
                            aux = listado[0];

                            lblNumIncidente.Text = "Incidente Nº " + aux.Id;
                            txtDetalle.Text = aux.Detalle;
                            ddlPrioridad.SelectedValue = aux.Prioridad.Id.ToString();
                            ddlTipo.SelectedValue = aux.Tipo.Id.ToString();
                            lblCreado.Text = "Creado el día " + aux.FechaCreacion.ToString("D");
                            // "D" -> sábado, 8 de junio de 2024
                            // "d" -> 08/06/2024
                            //cliente
                            lblNombreApellido.Text = aux.Cliente.Nombre + " " + aux.Cliente.Apellido;
                            lblDocumento.Text = aux.Cliente.Dni;

                            List<Estado> estados = Session["estados"] as List<Estado>; ;
                            Estado estado = estados.Find(x => x.Id == aux.Estado.Id);
                            if (estado != null)
                                lblEstado.Text = estado.Nombre;
                            else
                                lblEstado.Text = "ERROR";
                            //vigente-vencido-proximo
                            //lblEstado.CssClass = "badge rounded-pill text-bg-success large-badge";

                            AccionNegocio accionNegocio = new AccionNegocio();
                            dgvAcciones.DataSource = accionNegocio.listar();//mandar id
                            dgvAcciones.DataBind();
                        }
                        else
                        {
                            Session.Add("error", "Incidente no encontrado222222." + id);
                            Response.Redirect("Error.aspx", false);
                        }
                    }
                }
                else
                {
                    Session.Add("error", "Incidente no encontrado.");
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
            //MiControl1.LabelText = "¡Has hecho clic en el botón en MiControl!";
        }
    }
}
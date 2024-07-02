using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class GestionIncidente : System.Web.UI.Page
    {
        public bool banderaReabrirCaso;
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
                    ddlTipoAccion.DataSource = listaTiposAcciones;
                    ddlTipoAccion.DataValueField = "Id";
                    ddlTipoAccion.DataTextField = "Nombre";
                    ddlTipoAccion.DataBind();
                    ddlTipoAccion.SelectedIndex = -1;
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
                            Session["Incidente"] = listado[0];
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

                            if (aux.Estado.Id == 3 || aux.Estado.Id == 6)
                            {
                                banderaReabrirCaso = true;
                                btnModificarIncidente.Enabled = false;
                                btnGuardarAccion.Enabled = false;
                            }
                            else
                            {
                                banderaReabrirCaso = false;
                                btnModificarIncidente.Enabled = true;
                                btnGuardarAccion.Enabled = true;
                            }
                            List<Estado> estados = Session["estados"] as List<Estado>; ;
                            Estado estado = estados.Find(x => x.Id == aux.Estado.Id);
                            if (estado != null)
                                lblEstado.Text = estado.Nombre;
                            else
                                lblEstado.Text = "ERROR";
                            //vigente-vencido-proximo
                            //lblEstado.CssClass = "badge rounded-pill text-bg-success large-badge";

                            cargarDGVAcciones(aux.Id);
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
            Response.Redirect("Incidentes.aspx", false);
        }

        protected void btnModificarIncidente_Click(object sender, EventArgs e)
        {
            Incidente aux = new Incidente();
            aux = (Incidente)Session["Incidente"];
            if (aux.Tipo.Id != short.Parse(ddlTipo.SelectedValue) || aux.Prioridad.Id != short.Parse(ddlPrioridad.SelectedValue))
            {
                aux.Tipo.Id = short.Parse(ddlTipo.SelectedValue);
                aux.Prioridad.Id = short.Parse(ddlPrioridad.SelectedValue);
                if (aux.Estado.Id == 1 || aux.Estado.Id == 5)//abierto-reabierto
                {
                    aux.Estado.Id = 4;//en analisis
                }
                modificarIncidente(aux);
                guardarAccion(12);
            }
        }

        protected void btnGuardarAccion_Click(object sender, EventArgs e)
        {
            guardarAccion();
        }

        protected void btnResolver_Click(object sender, EventArgs e)
        {
            if (txtDetalleAccion.Text != "")
            {
                guardarAccion(4);
                botonesCasoAbierto(false);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            if (txtDetalleAccion.Text != "")
            {
                guardarAccion(3);
                botonesCasoAbierto(false);
            }
        }
        protected void guardarAccion(int id = 0)
        {
            Incidente aux = new Incidente();
            aux = (Incidente)Session["Incidente"];
            Usuario user = new Usuario();
            user = (Usuario)Session["usuario"];
            Accion accionAux = new Accion();
            accionAux.IDIncidente = aux.Id;
            accionAux.IDUsuario = user.Id;
            accionAux.Tipo = new TipoAccion();
            accionAux.Detalle = txtDetalleAccion.Text;
            switch (id)
            {
                case 0:
                    accionAux.Tipo.Id = short.Parse(ddlTipoAccion.SelectedValue);
                    break;
                case 3://cierre
                    accionAux.Tipo.Id = 3;
                    break;
                case 4://resolucion
                    accionAux.Tipo.Id = 4;
                    break;
                case 5://re-apertura
                    accionAux.Tipo.Id = 5;
                    break;
                case 12://modificacion tipo/prioridad
                    accionAux.Detalle = "Modificación tipo incidente y/o prioridad.";
                    accionAux.Tipo.Id = 12;
                    break;
                default:
                    break;
            }
            AccionNegocio accionNegocio = new AccionNegocio();
            accionNegocio.agregar(accionAux);
            cargarDGVAcciones(aux.Id);
            if (aux.Estado.Id == 1 || (aux.Estado.Id == 5 && accionAux.Tipo.Id !=5))//abierto-reabierto
            {
                aux.Estado.Id = 4;//en analisis
                modificarIncidente(aux);
            }
        }
        protected void cargarDGVAcciones(long id)
        {
            AccionNegocio accionNegocio = new AccionNegocio();
            dgvAcciones.DataSource = accionNegocio.listar(id.ToString());
            dgvAcciones.DataBind();
        }

        protected void modificarIncidente(Incidente aux)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            incidenteNegocio.modificar(aux);
        }

        protected void btnReabrir_Click(object sender, EventArgs e)
        {
            Incidente aux = new Incidente();
            aux = (Incidente)Session["Incidente"];
            aux.Estado.Id = 5;//re-apertura
            modificarIncidente(aux);
            guardarAccion(5);
            botonesCasoAbierto(true);
        }
        protected void botonesCasoAbierto(bool bandera)
        {
            banderaReabrirCaso = !bandera;
            btnModificarIncidente.Enabled = bandera;
            btnGuardarAccion.Enabled = bandera;
            ddlPrioridad.Enabled = bandera;
            ddlTipo.Enabled = bandera;
            ddlTipoAccion.Enabled = bandera;
        }
    }
}
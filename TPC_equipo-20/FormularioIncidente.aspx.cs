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
    public partial class FormularioIncidente : System.Web.UI.Page
    {
        public bool banderaCliente;
        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                if (!IsPostBack)
                {
                    banderaCliente = false;
                    PrioridadNegocio PrioridadNegocio = new PrioridadNegocio();
                    List<Prioridad> listaPrioridades = PrioridadNegocio.listar();

                    ddlPrioridad.DataSource = listaPrioridades;
                    ddlPrioridad.DataValueField = "Id";
                    ddlPrioridad.DataTextField = "Nombre";
                    ddlPrioridad.DataBind();
                    //ddlPrioridad.SelectedValue = "1";

                    TipoIncidenteNegocio TipoNegocio = new TipoIncidenteNegocio();
                    List<TipoIncidente> listaTipos = TipoNegocio.listar();

                    ddlTipo.DataSource = listaTipos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Nombre";
                    ddlTipo.DataBind();
                    //ddlTipo.SelectedValue = "1";

                    dgvClientes.DataSource = null;
                    dgvClientes.DataBind();
                }

                // En caso de que se haya pasado un id por querystring, se cargan los datos del cliente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    //buscar y mostrar
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    List<Cliente> listaAux = clienteNegocio.listar(id);
                    Cliente aux;
                    if (listaAux.Count > 0)
                    {
                        aux = listaAux[0];
                        lblNombreApellido.Text = aux.Nombre + " " + aux.Apellido;
                        lblDocumento.Text = aux.Dni;
                        //mostrar mas campos.
                        Session["Cliente"] = aux;
                        banderaCliente = true;
                    }
                    else
                    {
                        Session.Add("error", "Cliente no encontrado.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    banderaCliente = false;
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
                EmailService emailService = new EmailService();
                // falta usuario
                //Usuario usuario = new Usuario();
                //UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                aux.Detalle = txtDetalle.Text;
                aux.Prioridad = new Prioridad();
                aux.Prioridad.Id = short.Parse(ddlPrioridad.SelectedValue);
                aux.Estado = new Estado();
                //aux.Estado.Id = short.Parse(ddlEstado.SelectedValue);
                aux.Tipo = new TipoIncidente();
                aux.Tipo.Id = short.Parse(ddlTipo.SelectedValue); 
                
                //usuario.Email = txtEmail.Text;

                if (Request.QueryString["id"] != null)
                {
                    aux.Id = long.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(aux);
                }
                else
                {
                    negocio.agregar(aux);
                    /*Acá mandaría el correo con el email del usuario*/
                    //emailService.armarCorreo(usuario.Email, "Incidente cargado con éxito", "otros datos..");
                    //emailService.enviarCorreo();
                    //Response.Redirect("Incidentes.aspx", false);
                }

                Response.Redirect("Incidentes.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}

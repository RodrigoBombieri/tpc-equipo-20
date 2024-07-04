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
                    Session["Cliente"] = null;
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
                    List<Cliente> listaAux = clienteNegocio.listar(true,id);
                    if (listaAux.Count > 0)
                    {
                        cargarInfoCliente(listaAux[0]);                        
                        Session["Cliente"] = listaAux[0];
                        banderaCliente = true;
                    }
                    else
                    {
                        Session.Add("error", "Cliente no encontrado.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnGuardarIncidente_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenteNegocio negocio = new IncidenteNegocio();
                Incidente aux = new Incidente();
                EmailService emailService = new EmailService();

                aux.Tipo = new TipoIncidente();
                aux.Tipo.Id = short.Parse(ddlTipo.SelectedValue);
                aux.Prioridad = new Prioridad();
                aux.Prioridad.Id = short.Parse(ddlPrioridad.SelectedValue);
                aux.Estado = new Estado();
                aux.Estado.Id = 1;//abierto
                aux.Cliente = new Cliente();
                aux.Cliente = (Cliente)Session["Cliente"];
                aux.Detalle = txtDetalle.Text;
                aux.UsuarioAsignado = new Usuario();
                aux.UsuarioAsignado = (Usuario)Session["usuario"];

                negocio.agregar(aux);
                /*Acá mandaría el correo con el email del usuario*/
                emailService.armarCorreo(aux.Cliente.Email, "Incidente cargado con éxito", "otros datos..");
                emailService.enviarCorreo();
                Response.Redirect("Incidentes.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Incidentes.aspx", false);
        }
        protected void cargarInfoCliente(Cliente aux)
        {
            lblNombreApellido.Text = aux.Nombre + " " + aux.Apellido;
            lblDocumento.Text = aux.Dni;
            //mostrar mas campos.
        }
        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvClientes.SelectedDataKey.Value.ToString();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                List<Cliente> listaAux = clienteNegocio.listar(true, id);
                if (listaAux.Count > 0)
                {
                    cargarInfoCliente(listaAux[0]);
                    Session["Cliente"] = listaAux[0];
                    banderaCliente = true;
                }
                else
                {
                    Session.Add("error", "Error al seleccionar el cliente.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvClientes.DataSource = Session["listadoClientes"];
                dgvClientes.PageIndex = e.NewPageIndex;
                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Incidentes.aspx", false);
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtFiltroCliente.Text != "")
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                List<Cliente> clientes = clienteNegocio.listar(false, txtFiltroCliente.Text);
                Session.Add("listadoClientes", clientes);
                dgvClientes.DataSource = clientes;
                dgvClientes.DataBind();
            }
        }
    }
}

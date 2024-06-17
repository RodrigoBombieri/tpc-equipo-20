using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_equipo_20
{
    public partial class DetalleCliente : System.Web.UI.Page
    {
        public bool confirmaEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                    List<Provincia> listaProvincias = provinciaNegocio.listar();

                    ddlProvincias.DataSource = listaProvincias;
                    ddlProvincias.DataValueField = "Id";
                    ddlProvincias.DataTextField = "Descripcion";
                    ddlProvincias.DataBind();

                    txtFechaCreacion.Enabled = false;
                    if (Request.QueryString["id"] != null)
                    {
                        long id = long.Parse(Request.QueryString["id"].ToString());
                        List<Cliente> temp = (List<Cliente>)Session["listaClientes"];
                        Cliente aux = temp.Find(x => x.Id == id);
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtDni.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTelefono1.Enabled = false;
                        txtTelefono2.Enabled = false;
                        txtFechaNac.Enabled = false;
                        txtCalle.Enabled = false;
                        txtNumero.Enabled = false;
                        txtPiso.Enabled = false;
                        txtDepartamento.Enabled = false;
                        txtLocalidad.Enabled = false;
                        ddlProvincias.Enabled = false;
                        txtCodigoPostal.Enabled = false;
                        txtObservaciones.Enabled = false;
                        txtNombre.Text = aux.Nombre;
                        txtApellido.Text = aux.Apellido;
                        txtDni.Text = aux.Dni;
                        txtEmail.Text = aux.Email;
                        txtTelefono1.Text = aux.Telefono1;
                        txtTelefono2.Text = aux.Telefono2;
                        txtFechaNac.Text = aux.FechaNacimiento.ToString("yyyy-MM-dd");
                        txtFechaCreacion.Text = aux.FechaCreacion.ToString("yyyy-MM-dd");
                        txtCalle.Text = aux.Domicilio.Calle;
                        txtNumero.Text = aux.Domicilio.Numero;
                        txtPiso.Text = aux.Domicilio.Piso;
                        txtDepartamento.Text = aux.Domicilio.Departamento;
                        txtObservaciones.Text = aux.Domicilio.Observaciones;
                        txtLocalidad.Text = aux.Domicilio.Localidad;
                        ddlProvincias.SelectedValue = aux.Domicilio.Provincia.Id.ToString();
                        txtCodigoPostal.Text = aux.Domicilio.CodigoPostal;
                    }
                    else
                    {
                        txtFechaCreacion.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminar = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminar.Checked)
                {
                    long id = long.Parse(Request.QueryString["id"].ToString());
                    List<Cliente> temp = (List<Cliente>)Session["listaClientes"];
                    Cliente aux = temp.Find(x => x.Id == id);
                    ClienteNegocio negocio = new ClienteNegocio();
                    negocio.eliminar(aux);
                    Session.Add("listaClientes", negocio.listar());
                    Response.Redirect("ListadoClientes.aspx", false);
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

            Domicilio auxDom = new Domicilio();
            DomicilioNegocio domNeg = new DomicilioNegocio();
            auxDom.Calle = txtCalle.Text;
            auxDom.Numero = txtNumero.Text;
            auxDom.Piso = txtPiso.Text;
            auxDom.Departamento = txtDepartamento.Text;
            auxDom.Observaciones = txtObservaciones.Text;
            auxDom.Localidad = txtLocalidad.Text;
            auxDom.Provincia = new Provincia();
            auxDom.Provincia.Id = short.Parse(ddlProvincias.SelectedValue);
            auxDom.CodigoPostal = txtCodigoPostal.Text;
            domNeg.agregar(auxDom);

            Cliente aux = new Cliente();
            ClienteNegocio cliNeg = new ClienteNegocio();
            aux.Nombre = txtNombre.Text;
            aux.Apellido = txtApellido.Text;
            aux.Dni = txtDni.Text;
            aux.Email = txtEmail.Text;
            aux.Telefono1 = txtTelefono1.Text;
            aux.Telefono2 = txtTelefono2.Text;
            aux.Domicilio = new Domicilio();
            aux.Domicilio.Id = domNeg.buscarUltimo();
            aux.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            aux.FechaCreacion = DateTime.Parse(txtFechaCreacion.Text);

            cliNeg.agregar(aux);

            Session.Add("listaClientes", cliNeg.listar());
            Response.Redirect("ListadoClientes.aspx", false);
        }
    }
}
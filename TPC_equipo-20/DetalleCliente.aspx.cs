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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtFechaCreacion.Enabled = false;
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
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
                        txtProvincia.Enabled = false;
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
                        txtProvincia.Text = aux.Domicilio.Provincia;
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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente aux = new Cliente();
            ClienteNegocio cliNeg = new ClienteNegocio();
            aux.Nombre = txtNombre.Text;
            aux.Apellido = txtApellido.Text;
            aux.Dni = txtDni.Text;
            aux.Email = txtEmail.Text;
            aux.Telefono1 = txtTelefono1.Text;
            aux.Telefono2 = txtTelefono2.Text;
            aux.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            aux.FechaCreacion = DateTime.Parse(txtFechaCreacion.Text);
            /*aux.Domicilio.Calle = txtCalle.Text;
            aux.Domicilio.Numero = txtNumero.Text;
            aux.Domicilio.Piso = txtPiso.Text;
            aux.Domicilio.Departamento = txtDepartamento.Text;
            aux.Domicilio.Observaciones = txtObservaciones.Text;
            aux.Domicilio.Localidad = txtLocalidad.Text;
            aux.Domicilio.Provincia = txtProvincia.Text;
            aux.Domicilio.CodigoPostal = txtCodigoPostal.Text;*/

            cliNeg.agregar(aux);
        }
    }
}
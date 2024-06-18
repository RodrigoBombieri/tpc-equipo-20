using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        public bool confirmaEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            confirmaEliminar = false;
            try
			{
                if (!IsPostBack)
                {
                    RolNegocio rolNegocio = new RolNegocio();
                    List<Rol> listaRoles = rolNegocio.listar();

                    ddlRoles.DataSource = listaRoles;
                    ddlRoles.DataValueField = "Id";
                    ddlRoles.DataTextField = "Nombre";
                    ddlRoles.DataBind();
                }

                // En caso de que se haya pasado un id por querystring, se cargan los datos del usuario
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if(id != "" && !IsPostBack)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = (negocio.listar(id))[0];

                    txtID.Text = usuario.Id.ToString();
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtNickname.Text = usuario.Nick;
                    txtDNI.Text = usuario.Dni;
                    txtTelefono.Text = usuario.Telefono;
                    txtEmail.Text = usuario.Email;
                    ddlRoles.SelectedValue = usuario.Rol.Id.ToString();
                    txtPassword.Text = usuario.Password;
                }
            }
			catch (Exception ex)
			{

				Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Nick = txtNickname.Text;
                nuevo.Dni = txtDNI.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Rol = new Rol();
                nuevo.Rol.Id = short.Parse(ddlRoles.SelectedValue);
                nuevo.Password = txtPassword.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = long.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
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
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.eliminar(int.Parse(txtID.Text));
                    Response.Redirect("Usuarios.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        if(usuario.Rol.Descripcion != "Administrador")
                        {
                            txtRol.Enabled = false;
                        }
                        txtRol.Text = usuario.Rol.Descripcion;
                        txtEmail.Text = usuario.Email;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        txtNickName.Text = usuario.Nick;
                        txtTelefono.Text = usuario.Telefono;
                        txtDni.Text = usuario.Dni;

                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];

                if (txtImgPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImgPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Email = txtEmail.Text;
                usuario.Nick = txtNickName.Text;
                usuario.Telefono = txtTelefono.Text;
                usuario.Dni = txtDni.Text;
                usuario.Rol.Descripcion = txtRol.Text;

                negocio.modificar(usuario);

                Image img = (Image)Master.FindControl("imgNuevoPerfil");
                if (img != null)
                {

                img.ImageUrl = "~/Images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
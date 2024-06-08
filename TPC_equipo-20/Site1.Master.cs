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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/user-login-authenticate-icon-human-600nw-1365533969.jpg";
            if (Page is Default)
            {
                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblSalir.Text = usuario.Email;
                    if(!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                    }
                }
            }

            //if(!(Page is Login || Page is Default || Page is Error))
            //{
            //    if (!Seguridad.SesionActiva(Session["usuario"]))
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //    else
            //    {
            //        Usuario usuario = (Usuario)Session["usuario"];
            //        lblSalir.Text = usuario.Email;
            //        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
            //        {
            //            imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
            //        }
            //    }
            //}
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
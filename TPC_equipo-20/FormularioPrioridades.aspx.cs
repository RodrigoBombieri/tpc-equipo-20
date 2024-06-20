using System;
using dominio;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;

namespace TPC_equipo_20
{
    public partial class FormularioPrioridades : System.Web.UI.Page
    {
        public bool confirmaEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminar = false;
            try
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if(id != "" && !IsPostBack)
                    {
                        PrioridadNegocio negocio = new PrioridadNegocio();
                        Prioridad aux = (negocio.buscar(id))[0];

                        txtNombre.Text = aux.Nombre;
                    }
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
                Prioridad aux = new Prioridad();
                PrioridadNegocio negocio = new PrioridadNegocio();
                aux.Nombre = txtNombre.Text;

                if (Request.QueryString["id"] != null)
                {
                    aux.Id = short.Parse((Request.QueryString["id"].ToString()));                  
                    negocio.ModificarPrioridad(aux.Id, aux.Nombre);
                }
                else
                {
                    negocio.agregar(aux.Nombre);
                }

                Response.Redirect("Prioridades.aspx", false);
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
                if(chkConfirmaEliminar.Checked)
                {
                    PrioridadNegocio negocio = new PrioridadNegocio();
                    negocio.EliminarPrioridad(int.Parse(Request.QueryString["id"].ToString()));
                    Response.Redirect("Prioridades.aspx", false);
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
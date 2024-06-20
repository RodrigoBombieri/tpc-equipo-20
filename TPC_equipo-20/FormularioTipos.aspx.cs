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
    public partial class FormularioTipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) {}

                // En caso de que se haya pasado un id por querystring, se cargan los datos del incidente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    TipoIncidenteNegocio negocio = new TipoIncidenteNegocio();
                    TipoIncidente aux = negocio.buscar(int.Parse(id));
                    if (aux != null)
                    {
                        Session.Add("tipo", aux);
                        txtNombre.Text = aux.Nombre;
                    }
                    else
                    {
                        Session.Add("error", "Tipo no encontrado");
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                //TipoIncidente tipoOriginal = Session["tipo"] != null ? (TipoIncidente)Session["tipo"] : null;
                TipoIncidente tipoOriginal = (TipoIncidente)Session["tipo"];
                if (tipoOriginal != null && tipoOriginal.Id != 0)
                {
                    if (tipoOriginal.Nombre == txtNombre.Text){
                        Response.Redirect("TiposIncidentes.aspx", false);
                        return;
                    }
                }
                //else
                //{
                //}
                if (!chequearRepetido())
                {
                    TipoIncidente aux = new TipoIncidente();
                    TipoIncidenteNegocio negocio = new TipoIncidenteNegocio();
                    aux.Nombre = txtNombre.Text;

                    if (Request.QueryString["id"] != null)
                    {
                        aux.Id = short.Parse(Request.QueryString["id"].ToString());
                        negocio.modificar(aux);
                    }
                    else
                    {
                        negocio.agregar(aux);
                    }
                    Response.Redirect("TiposIncidentes.aspx", false);
                }
                else
                {
                    Session.Add("error", "El tipo ya existe");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
        protected bool chequearRepetido()
        {
            TipoIncidenteNegocio negocio = new TipoIncidenteNegocio();
            TipoIncidente aux = negocio.buscar(txtNombre.Text);
            if (aux != null)
                return true;
            else
            {
                Session.Add("error", "Tipo no encontrado");
                Response.Redirect("Error.aspx", false);
            }
            return false;
        }
    }
}
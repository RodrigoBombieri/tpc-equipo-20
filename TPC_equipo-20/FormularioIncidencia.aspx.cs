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
    public partial class FormularioIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                if (!IsPostBack)
                {
                    ddlPrioridad.Items.Add("Baja");
                    ddlPrioridad.Items.Add("Media");
                    ddlPrioridad.Items.Add("Alta");
                    ddlEstado.Items.Add("1");
                    ddlEstado.Items.Add("2");
                    ddlEstado.Items.Add("3");
                }

                // En caso de que se haya pasado un id por querystring, se cargan los datos del incidente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente aux = (negocio.listar(id))[0];

                    txtDetalle.Text = aux.Detalle;
                    ddlEstado.SelectedValue = "1";
                    ddlPrioridad.SelectedValue = "2";
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

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

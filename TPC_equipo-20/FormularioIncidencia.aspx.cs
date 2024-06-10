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

            ddlPrioridad.Items.Add("Baja");
            ddlPrioridad.Items.Add("Media");
            ddlPrioridad.Items.Add("Alta");
            ddlEstado.Items.Add("1");
            ddlEstado.Items.Add("2");
            ddlEstado.Items.Add("3");
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

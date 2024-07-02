using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class ControlUsuarios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Código que se ejecuta solo la primera vez que se carga el control
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "¡Has hecho clic en el botón en MiControl!";
        }
        public string LabelText
        {
            get { return Label1.Text; }
            set { Label1.Text = value; }
        }
    }
}
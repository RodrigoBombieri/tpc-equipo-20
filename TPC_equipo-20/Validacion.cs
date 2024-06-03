using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public class Validacion
    {
        // Valida que el texto del control no sea nulo (para usar en el login)
       
        public static bool ValidaTextoVacio(object control)
        {
            if(control is TextBox texto)
            {
                if(string.IsNullOrEmpty(texto.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        /// Verifica si la sesión está activa, es decir, si el usuario está logueado.
        /// obj es el objeto que se recibe en la página, que debería ser un Usuario.
        /// Retorna true si la sesión está activa, false en caso contrario.
        public static bool SesionActiva(Object obj)
        {
            Usuario usuario = obj != null ? (Usuario)obj : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsAdmin(Object obj)
        {
            Usuario usuario = obj != null ? (Usuario)obj : null;
            if (usuario != null && usuario.Rol.Id == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsSupervisor(Object obj)
        {
            Usuario usuario = obj != null ? (Usuario)obj : null;
            if (usuario != null && usuario.Rol.Id == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsTelefonista(Object obj)
        {
            Usuario usuario = obj != null ? (Usuario)obj : null;
            if (usuario != null && usuario.Rol.Id == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("select ID, Nombre from Estados");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    Estado aux = new Estado();
                    aux.Id = (short)acceso.Lector["ID"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}

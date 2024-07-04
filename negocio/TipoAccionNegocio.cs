using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class TipoAccionNegocio
    {
        public List<TipoAccion> listar()
        {
            List<TipoAccion> lista = new List<TipoAccion>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("select ID, Nombre from TiposAcciones where Automatico = 0");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    TipoAccion aux = new TipoAccion();
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

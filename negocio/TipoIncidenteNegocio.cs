using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TipoIncidenteNegocio
    {
        public List<TipoIncidente> listar()
        {
            List<TipoIncidente> lista = new List<TipoIncidente>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("select ID, Nombre from TiposIncidente");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    TipoIncidente aux = new TipoIncidente();
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

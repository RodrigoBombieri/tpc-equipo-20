using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Provincia> lista = new List<Provincia>();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre FROM Provincias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();
                    aux.Id = (short)datos.Lector["ID"];
                    aux.Descripcion = (string)datos.Lector["Nombre"];
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
                datos.cerrarConexion();
            }
        }
    }
}

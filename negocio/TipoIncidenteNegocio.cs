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
                acceso.setearConsulta("select ID, Nombre from TiposIncidentes");
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

        public List<TipoIncidente> buscar(string id = "")
        {
            List<TipoIncidente> lista = new List<TipoIncidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (id != "")
                {
                    datos.setearConsulta("Select ID, Nombre " +
                    "FROM TiposIncidentes " +
                    "Where ID = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }
                while (datos.Lector.Read())
                {
                    TipoIncidente aux = new TipoIncidente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (short)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(TipoIncidente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into TiposIncidentes " +
                    "(Nombre) VALUES (@Nombre)");

                datos.setearParametro("@Nombre", aux.Nombre);

                datos.ejecutarAccion();
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

        public void modificar(TipoIncidente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE TiposIncidentes SET Nombre = @Nombre " +
                    "where ID = @id");
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@Nombre", aux.Nombre);
                datos.ejecutarAccion();
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

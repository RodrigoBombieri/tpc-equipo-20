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
                acceso.setearConsulta("select ID, Nombre, IDPrioridad from TiposIncidentes");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    TipoIncidente aux = new TipoIncidente();
                    aux.Id = (short)acceso.Lector["ID"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.IDPrioridad = (short)acceso.Lector["IDPrioridad"];
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

        public TipoIncidente buscar(int id = -1)
        {
            List<TipoIncidente> lista = new List<TipoIncidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (id != -1)
                {
                    datos.setearConsulta("Select ID, Nombre, IDPrioridad " +
                    "FROM TiposIncidentes " +
                    "Where ID = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }
                TipoIncidente aux = new TipoIncidente();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (short)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDPrioridad = (short)datos.Lector["IDPrioridad"];
                }
                else
                {
                    aux = null;
                }
                datos.cerrarConexion();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TipoIncidente buscar(string nombre = "")
        {
            List<TipoIncidente> lista = new List<TipoIncidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (nombre != "")
                {
                    datos.setearConsulta("Select ID, Nombre, IDPrioridad " +
                    "FROM TiposIncidentes " +
                    "Where Nombre = @Nombre");
                    datos.setearParametro("@Nombre", nombre);
                    datos.ejecutarLectura();
                }
                TipoIncidente aux = new TipoIncidente();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (short)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDPrioridad = (short)datos.Lector["IDPrioridad"];
                }
                else
                {
                    aux = null;
                }
                datos.cerrarConexion();
                return aux;
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
                    "(Nombre,IDPrioridad) VALUES (@Nombre, @IDPrioridad)");

                datos.setearParametro("@Nombre", aux.Nombre);
                datos.setearParametro("@IDPrioridad", aux.IDPrioridad);

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
                datos.setearConsulta("UPDATE TiposIncidentes SET Nombre = @Nombre, IDPrioridad = @IDPrioridad " +
                    "where ID = @id");
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@Nombre", aux.Nombre);
                datos.setearParametro("@IDPrioridad", aux.IDPrioridad);
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

using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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

        public List<Estado> buscar(string id = "")
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(id != "")
                {
                    datos.setearConsulta("select ID, Nombre from Estados where ID = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }

                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
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

        public void modificar(int id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Estados set Nombre = @nombre where ID = @id");
                datos.setearParametro("@nombre", nombre);
                datos.setearParametro("@id", id);
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

        public void agregar(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Estados (Nombre) values (@nombre)");
                datos.setearParametro("@nombre", nombre);
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
        
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Estados where ID = @id");
                datos.setearParametro("@id", id);
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

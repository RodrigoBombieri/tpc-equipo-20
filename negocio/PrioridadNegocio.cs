using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> listar()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("select ID, Nombre from PRIORIDADES");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
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

        public void agregar(string nombre)
        {
            AccesoDatos conexion = new AccesoDatos();
            conexion.setearConsulta("  INSERT INTO PRIORIDADES (Nombre) VALUES (@nombre)");
            conexion.setearParametro("nombre", nombre);
            conexion.ejecutarAccion();

            conexion.cerrarConexion();
        }

        /* public int ProximoID()
         {
             int id = 0;
             AccesoDatos conexion = new AccesoDatos();
             conexion.setearConsulta(" SELECT MAX(ID) +1 AS ProximoId FROM PRIORIDADES;");
             conexion.ejecutarLectura();
             conexion.Lector.Read();
             id = (int)conexion.Lector["ProximoId"];
             return id;
         }
       */


        public void ModificarPrioridad(int id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("update PRIORIDADES set Nombre = @nombre where ID = @id");
            datos.setearParametro("nombre", nombre);
            datos.setearParametro("id", id);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }
        public void EliminarPrioridad(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("delete from PRIORIDADES where ID = @id ");
                datos.setearParametro("id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            finally
            {

                datos.cerrarConexion();

            }

        }

        public List<Prioridad> buscar(string id = "")
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (id != "")
                {
                    datos.setearConsulta("Select ID, Nombre " +
                    "FROM Prioridades " +
                    "Where ID = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }
                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
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
    }
}

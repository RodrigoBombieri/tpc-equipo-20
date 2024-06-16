using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class IncidenteNegocio
    {
        public List<Incidente> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Incidente> lista = new List<Incidente>();

            try
            {
                datos.setearConsulta("Select I.ID, I.IDTipo, TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre,  " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle " +
                    "I.FechaCreacion, I.FechaCierre " +
                    "FROM Incidentes I " +
                    "inner join TiposIncidente TI on I.IDTipo = TI.ID " +
                    "inner join Prioridades P on I.IDPrioridad = P.ID " +
                    "inner join Estados E on I.IDEstado = E.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (int)datos.Lector["ID"];
                    aux.Tipo.Id = (int)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Prioridad.Id = (int)datos.Lector["IDPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
                    aux.Estado.Id = (int)datos.Lector["IDEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
                    aux.UsuarioAsignado = (int)datos.Lector["UsuarioAsignado"];
                    aux.UsuarioCreador = (int)datos.Lector["UsuarioCreador"];
                    aux.Detalle = (string)datos.Lector["Detalle"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];
                  
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

        public List<Incidente> listar(string id = "")
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select I.ID, I.IDTipo, TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre,  " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle " +
                    "I.FechaCreacion, I.FechaCierre " +
                    "FROM Incidentes I " +
                    "inner join TiposIncidente TI on I.IDTipo = TI.ID " +
                    "inner join Prioridades P on I.IDPrioridad = P.ID " +
                    "inner join Estados E on I.IDEstado = E.ID");
                if (id != "")
                {
                    datos.setearConsulta("Select I.ID, I.IDTipo, TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre,  " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle " +
                    "I.FechaCreacion, I.FechaCierre " +
                    "FROM Incidentes I " +
                    "inner join TiposIncidente TI on I.IDTipo = TI.ID " +
                    "inner join Prioridades P on I.IDPrioridad = P.ID " +
                    "inner join Estados E on I.IDEstado = E.ID " +
                    "Where I.ID = @id");
                                        
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (int)datos.Lector["ID"];
                    aux.Tipo.Id = (int)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Prioridad.Id = (int)datos.Lector["IDPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
                    aux.Estado.Id = (int)datos.Lector["IDEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
                    aux.UsuarioAsignado = (int)datos.Lector["UsuarioAsignado"];
                    aux.UsuarioCreador = (int)datos.Lector["UsuarioCreador"];
                    aux.Detalle = (string)datos.Lector["Detalle"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

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
        public void agregar(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
      
                datos.setearConsulta("insert into Incidentes " +
                    "(IDPrioridad, IDEstado, UsuarioAsignado, UsuarioCreador, " +
                    "Detalle, FechaCreacion, FechaCierre) " +
                    "VALUES (@IDPrioridad, @IDEstado, @UsuarioAsignado, @UsuarioCreador, " +
                    "@Detalle, @FechaCreacion, @FechaCierre");
                datos.setearParametro("@IDPrioridad", nuevo.Prioridad.Id);
                datos.setearParametro("@IDEstado", nuevo.Estado.Id);
                datos.setearParametro("@UsuarioAsignado", nuevo.UsuarioAsignado);
                datos.setearParametro("@UsuarioCreador", nuevo.UsuarioCreador);
                datos.setearParametro("@Detalle", nuevo.Detalle);
                datos.setearParametro("@FechaCreacion", nuevo.FechaCreacion);
                datos.setearParametro("@FechaCierre", nuevo.FechaCierre);
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

        public Incidente buscar(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Incidente aux = new Incidente();
            try
            {                
                return aux;
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

        public int buscarUltimo()
        {
            AccesoDatos datos = new AccesoDatos();
            int id = -1;
            try
            {
                return id;
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

        public void modificar(Usuario aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Email = @email, Nombre = @nombre, Apellido = @apellido," +
                    " Nick = @nick, IDRol = @idRol, Telefono = @telefono, Dni = @dni, urlImagenPerfil = @imagen Where ID = @id");
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@email", aux.Email);
                datos.setearParametro("@nombre", aux.Nombre);
                datos.setearParametro("@apellido", aux.Apellido);
                datos.setearParametro("@nick", aux.Nick);
                datos.setearParametro("@telefono", aux.Telefono);
                datos.setearParametro("@dni", aux.Dni);
                datos.setearParametro("@imagen", (object)aux.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@idRol", aux.Rol.Id);
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
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Incidentes where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

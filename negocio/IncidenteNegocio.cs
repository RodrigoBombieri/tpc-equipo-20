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
                datos.setearConsulta("Select I.ID, I.IDtipo, " +
                    "TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre,  " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle, " +
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
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Tipo = new TipoIncidente();
                    aux.Tipo.Id = (short)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["TipoNombre"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (short)datos.Lector["IDPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (short)datos.Lector["IDEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
                    aux.UsuarioAsignado = (long)datos.Lector["UsuarioAsignado"];
                    aux.UsuarioCreador = (long)datos.Lector["UsuarioCreador"];
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
                if (id != "")
                {
                    datos.setearConsulta("Select I.ID, I.IDtipo, " +
                    "TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre,  " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle, " +
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
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Tipo = new TipoIncidente();
                    aux.Tipo.Id = (short)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["TipoNombre"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (short)datos.Lector["IDPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (short)datos.Lector["IDEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
                    aux.UsuarioAsignado = (long)datos.Lector["UsuarioAsignado"];
                    aux.UsuarioCreador = (long)datos.Lector["UsuarioCreador"];
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
        public void agregar(Incidente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Incidentes " +
                    "(IDTipo, IDPrioridad, IDEstado, UsuarioAsignado, UsuarioCreador, " +
                    "Detalle, FechaCreacion, FechaCierre) " +
                    "VALUES (@IDTipo, @IDPrioridad, @IDEstado, @UsuarioAsignado, @UsuarioCreador, " +
                    "@Detalle, GETDATE(), GETDATE())");            

                datos.setearParametro("@IdTipo", aux.Tipo.Id);
                datos.setearParametro("@IDPrioridad", aux.Prioridad.Id);
                datos.setearParametro("@IDEstado", aux.Estado.Id);
                datos.setearParametro("@UsuarioAsignado", aux.UsuarioAsignado);
                datos.setearParametro("@UsuarioCreador", aux.UsuarioCreador);
                datos.setearParametro("@Detalle", aux.Detalle);
                //datos.setearParametro("@FechaCreacion", aux.FechaCreacion);
                //datos.setearParametro("@FechaCierre", aux.FechaCierre);

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

        public void modificar(Incidente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Incidentes SET IDTipo = @IdTipo, IDPrioridad = @IDPrioridad, IDEstado = @IDEstado," +
                    " UsuarioAsignado = @UsuarioAsignado, UsuarioCreador = @UsuarioCreador, Detalle = @Detalle, " +
                    "FechaCreacion = @FechaCreacion, FechaCierre = @FechaCierre " +
                    "where ID = @id");
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@IdTipo", aux.Tipo);
                datos.setearParametro("@IDPrioridad", aux.Prioridad);
                datos.setearParametro("@IDEstado", aux.Estado);
                datos.setearParametro("@UsuarioAsignado", aux.UsuarioAsignado);
                datos.setearParametro("@UsuarioCreador", aux.UsuarioCreador);
                datos.setearParametro("@Detalle", aux.Detalle);
                datos.setearParametro("@FechaCreacion", aux.FechaCreacion);
                datos.setearParametro("@FechaCierre", aux.FechaCierre);
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

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
        public List<Incidente> listar(string id="")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Incidente> lista = new List<Incidente>();

            try
            {
                datos.setearConsulta("Select I.ID, I.IDtipo, " +
                    "TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre, " +
                    "c.ID as IDCliente, c.Nombre, c.Apellido, c.Dni, c.Telefono1, c.Telefono2, c.Email, c.FechaNacimiento, c.FechaCreacion, c.IDDomicilio, d.Calle, d.Numero, d.Piso, d.Departamento, d.Observaciones, d.Localidad, d.CodigoPostal, d.IDProvincia, pr.Nombre as Provincia, " +
                    "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle, " +
                    "I.FechaCreacion, I.FechaCierre " +
                    "FROM Incidentes I " +
                    "inner join TiposIncidentes TI on I.IDTipo = TI.ID " +
                    "inner join Prioridades P on I.IDPrioridad = P.ID " +
                    "inner join Estados E on I.IDEstado = E.ID " +
                    "inner join Clientes c on I.IDCliente = C.ID " +
                    "inner join Domicilios d ON d.Id = c.IDDomicilio " +                    
                    "inner join Provincias pr ON pr.ID = d.IDProvincia");
                    //agregar el id
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

                    aux.Cliente = new Cliente();
                    aux.Id = (long)datos.Lector["IDCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cliente.Dni = (string)datos.Lector["Dni"];
                    if (!(datos.Lector["Telefono1"] is DBNull))
                        aux.Cliente.Telefono1 = (string)datos.Lector["Telefono1"];
                    if (!(datos.Lector["Telefono2"] is DBNull))
                        aux.Cliente.Telefono2 = (string)datos.Lector["Telefono2"];
                    aux.Cliente.Email = (string)datos.Lector["Email"];
                    aux.Cliente.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                    aux.Cliente.FechaCreacion = DateTime.Parse(datos.Lector["FechaCreacion"].ToString());
                    aux.Cliente.Domicilio = new Domicilio();
                    aux.Cliente.Domicilio.Id = (long)datos.Lector["IDDomicilio"];
                    aux.Cliente.Domicilio.Calle = (string)datos.Lector["Calle"];
                    aux.Cliente.Domicilio.Numero = (string)datos.Lector["Numero"];
                    if (!(datos.Lector["Piso"] is DBNull))
                        aux.Cliente.Domicilio.Piso = (string)datos.Lector["Piso"];
                    if (!(datos.Lector["Departamento"] is DBNull))
                        aux.Cliente.Domicilio.Departamento = (string)datos.Lector["Departamento"];
                    if (!(datos.Lector["Observaciones"] is DBNull))
                        aux.Cliente.Domicilio.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Cliente.Domicilio.Localidad = (string)datos.Lector["Localidad"];
                    aux.Cliente.Domicilio.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Cliente.Domicilio.Provincia = new Provincia();
                    aux.Cliente.Domicilio.Provincia.Id = (short)datos.Lector["IDProvincia"];
                    aux.Cliente.Domicilio.Provincia.Descripcion = (string)datos.Lector["Provincia"];
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

        //public List<Incidente> listar(string id = "")
        //{
        //    List<Incidente> lista = new List<Incidente>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        if (id != "")
        //        {
        //            datos.setearConsulta("Select I.ID, I.IDtipo, " +
        //            "TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
        //            "I.IDEstado, E.Nombre as EstadoNombre,  " +
        //            "I.UsuarioAsignado, I.UsuarioCreador, I.Detalle, " +
        //            "I.FechaCreacion, I.FechaCierre " +
        //            "FROM Incidentes I " +
        //            "inner join TiposIncidentes TI on I.IDTipo = TI.ID " +
        //            "inner join Prioridades P on I.IDPrioridad = P.ID " +
        //            "inner join Estados E on I.IDEstado = E.ID " +
        //            "Where I.ID = @id");

        //            datos.setearParametro("@id", id);
        //            datos.ejecutarLectura();
        //        }
        //        while (datos.Lector.Read())
        //        {
        //            Incidente aux = new Incidente();
        //            if (!(datos.Lector["ID"] is DBNull))
        //                aux.Id = (long)datos.Lector["ID"];
        //            aux.Tipo = new TipoIncidente();
        //            aux.Tipo.Id = (short)datos.Lector["IDTipo"];
        //            aux.Tipo.Nombre = (string)datos.Lector["TipoNombre"];
        //            aux.Prioridad = new Prioridad();
        //            aux.Prioridad.Id = (short)datos.Lector["IDPrioridad"];
        //            aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
        //            aux.Estado = new Estado();
        //            aux.Estado.Id = (short)datos.Lector["IDEstado"];
        //            aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
        //            aux.UsuarioAsignado = (long)datos.Lector["UsuarioAsignado"];
        //            aux.UsuarioCreador = (long)datos.Lector["UsuarioCreador"];
        //            aux.Detalle = (string)datos.Lector["Detalle"];
        //            aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
        //            aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

        //            lista.Add(aux);
        //        }
        //        datos.cerrarConexion();
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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

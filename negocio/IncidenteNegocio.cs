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
        public List<Incidente> listar(bool esIdUsuario, string id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Incidente> lista = new List<Incidente>();

            try
            {
                string query = "Select I.ID as IDIncidente, I.IDtipo, " +
                    "TI.Nombre as TipoNombre, I.IDPrioridad, P.Nombre as PrioridadNombre, " +
                    "I.IDEstado, E.Nombre as EstadoNombre, " +
                    "c.ID as IDCliente, c.Nombre, c.Apellido, c.Dni, c.Telefono1, c.Telefono2," +
                    "c.Email, c.FechaNacimiento, c.FechaCreacion, c.IDDomicilio, d.Calle, d.Numero, " +
                    "d.Piso, d.Departamento, d.Observaciones, d.Localidad, d.CodigoPostal, d.IDProvincia, " +
                    "pr.Nombre as Provincia, " +
                    "U.ID as IDUsuario, U.Nombre as NombreUsuario, U.Apellido as ApellidoUsuario, U.Nick, " +
                    "U.Dni as UsuarioDNI, U.Telefono as TelefonoUsuario, U.Email as EmailUsuario, U.urlImagenPerfil, " +
                    "R.ID as IDRol, R.Nombre as NombreRol, " +
                    "I.Detalle, I.FechaCreacion as CreacionIncidente, I.FechaCierre, " +
                    "DATEADD(day, P.Vigencia, I.FechaCreacion) AS Vencimiento, " +
                    "CAST(CASE WHEN DATEADD(day, P.Vigencia, I.FechaCreacion) < GETDATE() THEN 1 ELSE 0  END AS bit) AS Vencido " +
                    "FROM Incidentes I " +
                    "inner join TiposIncidentes TI on I.IDTipo = TI.ID " +
                    "inner join Prioridades P on I.IDPrioridad = P.ID " +
                    "inner join Estados E on I.IDEstado = E.ID " +
                    "inner join Clientes c on I.IDCliente = C.ID " +
                    "inner join Domicilios d ON d.Id = c.IDDomicilio " +
                    "inner join Provincias pr ON pr.ID = d.IDProvincia " +
                    "inner join Usuarios U on I.IDUsuario = U.ID " +
                    "inner join Roles R on U.IDRol = R.ID";


                if (id != "" && !esIdUsuario)
                {
                    query += " where I.ID = @id";
                    datos.setearParametro("@id", id);
                }
                else if (id != "" && esIdUsuario)
                {
                    query += " where I.IDUsuario = @idUsuario";
                    datos.setearParametro("@idUsuario", id);
                }
                datos.setearConsulta(query);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    if (!(datos.Lector["IDIncidente"] is DBNull))
                        aux.Id = (long)datos.Lector["IDIncidente"];
                    aux.Tipo = new TipoIncidente();
                    aux.Tipo.Id = (short)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["TipoNombre"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (short)datos.Lector["IDPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["PrioridadNombre"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (short)datos.Lector["IDEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["EstadoNombre"];
                    if (!(datos.Lector["Detalle"] is DBNull))
                        aux.Detalle = (string)datos.Lector["Detalle"];
                    aux.FechaCreacion = (DateTime)datos.Lector["CreacionIncidente"];
                    aux.FechaVencimiento = (DateTime)datos.Lector["Vencimiento"];
                    aux.Vencido = (bool)datos.Lector["Vencido"];
                    if (!(datos.Lector["FechaCierre"] is DBNull))
                        aux.FechaCierre = (DateTime)datos.Lector["FechaCierre"];

                    //usuario
                    aux.UsuarioAsignado = new Usuario();
                    aux.UsuarioAsignado.Id = (long)datos.Lector["IDUsuario"];
                    aux.UsuarioAsignado.Nombre = (string)datos.Lector["NombreUsuario"];
                    aux.UsuarioAsignado.Apellido = (string)datos.Lector["ApellidoUsuario"];
                    aux.UsuarioAsignado.Nick = (string)datos.Lector["Nick"];
                    aux.UsuarioAsignado.Dni = (string)datos.Lector["UsuarioDNI"];
                    if (!(datos.Lector["TelefonoUsuario"] is DBNull))
                        aux.UsuarioAsignado.Telefono = (string)datos.Lector["TelefonoUsuario"];
                    aux.UsuarioAsignado.Email = (string)datos.Lector["EmailUsuario"];
                    aux.UsuarioAsignado.Rol = new Rol();
                    aux.UsuarioAsignado.Rol.Id = (short)datos.Lector["IDRol"];
                    aux.UsuarioAsignado.Rol.Descripcion = (string)datos.Lector["NombreRol"];
                    aux.UsuarioAsignado.Password = "";
                    //aux.UsuarioAsignado.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    //chequear si no es null
                    aux.UsuarioAsignado.ImagenPerfil = "";

                    //cliente
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (long)datos.Lector["IDCliente"];
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

        public void agregar(Incidente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Incidentes " +
                    "(IDTipo, IDPrioridad, IDEstado, IDCliente, IDUsuario, " +
                    "Detalle, FechaCreacion) " +
                    "VALUES (@IDTipo, @IDPrioridad, @IDEstado, @IDCliente, @IDUsuario, " +
                    "@Detalle, GETDATE())");

                datos.setearParametro("@IdTipo", aux.Tipo.Id);
                datos.setearParametro("@IDPrioridad", aux.Prioridad.Id);
                datos.setearParametro("@IDEstado", aux.Estado.Id);
                datos.setearParametro("@IDCliente", aux.Cliente.Id);
                datos.setearParametro("@IDUsuario", aux.UsuarioAsignado.Id);
                datos.setearParametro("@Detalle", aux.Detalle);
                //datos.setearParametro("@FechaCreacion", DateTime.Now.Date);
                //datos.setearParametro("@FechaCierre", null);

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
                    " IDUsuario = @UsuarioAsignado, Detalle = @Detalle, " +
                    "FechaCreacion = @FechaCreacion, FechaCierre = @FechaCierre " +
                    "where ID = @id");
                datos.setearParametro("@id", aux.Id);
                datos.setearParametro("@IdTipo", aux.Tipo.Id);
                datos.setearParametro("@IDPrioridad", aux.Prioridad.Id);
                datos.setearParametro("@IDEstado", aux.Estado.Id);
                datos.setearParametro("@UsuarioAsignado", aux.UsuarioAsignado.Id);
                datos.setearParametro("@Detalle", aux.Detalle);
                datos.setearParametro("@FechaCreacion", aux.FechaCreacion);
                datos.setearParametro("@FechaCierre", (object)aux.FechaCierre ?? DBNull.Value);
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

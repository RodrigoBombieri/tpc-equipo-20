using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearConsulta("SELECT c.ID, c.Nombre, c.Apellido, c.Dni, c.Telefono1, c.Telefono2, c.Email, c.FechaNacimiento, c.FechaCreacion, d.Id as IDDomicilio, d.Calle, d.Numero, d.Piso, d.Departamento, d.Observaciones, d.CodigoPostal, l.Nombre as Localidad, pr.ID as IDProvincia, pr.Nombre as Provincia " +
                    "FROM Clientes c JOIN Domicilios d ON d.Id = c.IDDomicilio JOIN Localidades l on d.IDLocalidad = l.ID JOIN Provincias pr ON pr.ID = l.IDProvincia");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    if (!(datos.Lector["Telefono1"] is DBNull))
                        aux.Telefono1 = (string)datos.Lector["Telefono1"];
                    if (!(datos.Lector["Telefono2"] is DBNull))
                        aux.Telefono2 = (string)datos.Lector["Telefono2"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                    aux.FechaCreacion = DateTime.Parse(datos.Lector["FechaCreacion"].ToString());
                    aux.Domicilio = new Domicilio();
                    aux.Domicilio.Provincia = new Provincia();
                    aux.Domicilio.Id = (long)datos.Lector["IDDomicilio"];
                    aux.Domicilio.Calle = (string)datos.Lector["Calle"];
                    aux.Domicilio.Numero = (string)datos.Lector["Numero"];
                    if (!(datos.Lector["Piso"] is DBNull))
                        aux.Domicilio.Piso = (string)datos.Lector["Piso"];
                    if (!(datos.Lector["Departamento"] is DBNull))
                        aux.Domicilio.Departamento = (string)datos.Lector["Departamento"];
                    if (!(datos.Lector["Observaciones"] is DBNull))
                        aux.Domicilio.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Domicilio.Localidad = (string)datos.Lector["Localidad"];
                    aux.Domicilio.Provincia.Id = (short)datos.Lector["IDProvincia"];
                    aux.Domicilio.Provincia.Descripcion = (string)datos.Lector["Provincia"];

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

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CLIENTES (Nombre, Apellido, Dni, Telefono1, Telefono2, Email, FechaNacimiento, FechaCreacion) VALUES (@nombre, @apellido, @nick, @dni, @telefono1, @telefono2, @email, @fechanac, @fechacreac)");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono1", nuevo.Telefono1);
                datos.setearParametro("@telefono2", nuevo.Telefono2);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@fechanac", nuevo.FechaNacimiento);
                datos.setearParametro("@fechacreac", nuevo.FechaCreacion);
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

        public void eliminar(Cliente cliente)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                DomicilioNegocio negocio = new DomicilioNegocio();

                long idDom = cliente.Domicilio.Id;
                long idCliente = cliente.Id;

                datos.setearConsulta("delete from CLIENTES where id = @id");
                datos.setearParametro("@id", idCliente);
                datos.ejecutarAccion();

                negocio.eliminar(idDom);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}

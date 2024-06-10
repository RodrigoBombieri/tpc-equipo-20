using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;
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
                datos.setearConsulta("SELECT c.ID, c.Nombre, c.Apellido, c.Dni, c.Telefono, c.Email, c.FechaNacimiento, c.FechaCreacion, d.Calle, d.Numero, d.Piso, d.Departamento, d.Observaciones, l.Nombre as Localidad, pr.Nombre as Provincia, p.Nombre as Pais,  l.CodigoPostal FROM Clientes c JOIN Domicilios d ON d.Id=c.IDDomicilio JOIN Localidades l on d.IDLocalidad=l.ID JOIN Provincias pr ON pr.ID=l.IDProvincia JOIN Paises p on p.Id=pr.IDPais");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                    {
                        aux.Telefono1 = (string)datos.Lector["Telefono"];
                        aux.Telefono2 = (string)datos.Lector["Telefono"];
                    }
                    aux.Email = (string)datos.Lector["Email"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Domicilio = new Domicilio();
                    aux.Domicilio.Calle = (string)datos.Lector["Calle"];
                    aux.Domicilio.Numero = (string)datos.Lector["Numero"];
                    if (!(datos.Lector["Piso"] is DBNull))
                        aux.Domicilio.Piso = (string)datos.Lector["Piso"];
                    if (!(datos.Lector["Departamento"] is DBNull))
                        aux.Domicilio.Departamento = (string)datos.Lector["Departamento"];
                    if (!(datos.Lector["Observaciones"] is DBNull))
                        aux.Domicilio.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Domicilio.Localidad = (string)datos.Lector["Localidad"];
                    aux.Domicilio.Provincia = (string)datos.Lector["Provincia"];
                    aux.Domicilio.Pais = (string)datos.Lector["Pais"];

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

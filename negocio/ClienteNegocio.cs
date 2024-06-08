using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    internal class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT c.ID, c.Nombre, c.Apellido, c.Dni, c.Telefono, c.Email, c.FechaNacimiento, c.FechaCreacion, d.Calle, d.Numero, d.Piso, d.Departamento, d.Observaciones, l.Nombre as Localidad, l.Provincia, l.CodigoPostal, p.Nombre as Pais" +
                   "FROM Clientes c JOIN Domicilios d ON d.Id=c.IDDomicilio JOIN Provincia JOIN Localidades l ON l.ID=d.IDLocalidad JOIN Paises p on p.Id=l.IDPais");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                    {
                        aux.Telefono = (string)datos.Lector["Telefono"];
                    }
                    aux.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                    {
                        aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    }
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

                    aux.Domicilio = new Domicilio();

                    aux.Domicilio.Calle = (string)datos.Lector["Calle"];
                    aux.Domicilio.Numero = (string)datos.Lector["Numero"];
                    aux.Domicilio.Piso = (string)datos.Lector["Piso"];
                    aux.Domicilio.Departamento = (string)datos.Lector["Departamento"];
                    aux.Domicilio.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Domicilio.Localidad = (string)datos.Lector["Numero"];
                    aux.Domicilio.Provincia = (string)datos.Lector["Provincia"];
                    aux.Domicilio.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Domicilio.Pais = (string)datos.Lector["Pais"];

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

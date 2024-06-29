using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccionNegocio
    {
        public List<Accion> listar(string id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Accion> lista = new List<Accion>();

            try
            {
                datos.setearConsulta("Select A.ID, A.IDIncidente, A.Detalle, A.UsuarioCreador, A.IDtipo, A.FechaCreacion, TA.Nombre " +
                    "FROM Acciones A " +
                    "inner join TiposAcciones TA on A.IDTipo = TA.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Accion aux = new Accion();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.IDIncidente = (long)datos.Lector["IDIncidente"];
                    aux.Detalle = (string)datos.Lector["Detalle"];
                    aux.IDUsuario = (long)datos.Lector["UsuarioCreador"];
                    aux.Tipo = new TipoAccion();
                    aux.Tipo.Id = (short)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Fecha = (DateTime)datos.Lector["FechaCreacion"];

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

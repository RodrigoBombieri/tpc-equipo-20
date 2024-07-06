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
        public List<Accion> listar(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Accion> lista = new List<Accion>();
            try
            {
                datos.setearConsulta("Select A.ID, A.IDIncidente, A.Detalle, A.IDUsuario, A.IDtipo, A.Fecha, TA.Nombre, U.Nombre as \"NombreUsuario\", U.ID " +
                    "FROM Acciones A " +
                    "inner join TiposAcciones TA on A.IDTipo = TA.ID INNER JOIN Usuarios U ON A.IDUsuario = U.ID INNER JOIN Incidentes I ON U.ID = I.ID " +
                    "where A.IDIncidente = @id order by Fecha desc");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Accion aux = new Accion();
                    Incidente incidente = new Incidente();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.IDIncidente = (long)datos.Lector["IDIncidente"];
                    aux.Detalle = (string)datos.Lector["Detalle"];
                    aux.IDUsuario = (long)datos.Lector["IDUsuario"];
                    aux.Tipo = new TipoAccion();
                    aux.Tipo.Id = (short)datos.Lector["IDTipo"];
                    aux.Tipo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Usuario = new Usuario();
                    aux.Usuario.Id = (long)datos.Lector["IDUsuario"];
                    aux.Usuario.Nombre = (string)datos.Lector["NombreUsuario"];

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

        public void agregar(Accion aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Acciones " +
                    "(IDIncidente, IDUsuario, Fecha, Detalle, IDTipo) " +
                    "VALUES (@IDIncidente, @IDUsuario, GETDATE(), @Detalle, @IDTipo)");
                datos.setearParametro("@IDIncidente", aux.IDIncidente);
                datos.setearParametro("@IDUsuario", aux.IDUsuario);
                datos.setearParametro("@Detalle", aux.Detalle);
                datos.setearParametro("@IDTipo", aux.Tipo.Id);

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

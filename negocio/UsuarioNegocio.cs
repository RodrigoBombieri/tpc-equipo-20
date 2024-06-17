using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("Select U.ID, U.Nombre, U.Apellido, Nick, Dni, Telefono, Email, Pass, IDRol, urlImagenPerfil, R.ID as RolID, R.Nombre as RolDescripcion FROM USUARIOS AS U, ROLES AS R Where U.IDRol = R.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nick = (string)datos.Lector["Nick"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Password = (string)datos.Lector["Pass"];
                    aux.Rol = new Rol();
                    aux.Rol.Id = (short)datos.Lector["RolID"];
                    aux.Rol.Descripcion = (string)datos.Lector["RolDescripcion"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        aux.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];


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

        public List<Usuario> listar(string id = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.ID, U.Nombre, U.Apellido, Nick, Dni, Telefono, Email, Pass, IDRol, urlImagenPerfil, R.ID as RolID, R.Nombre as RolDescripcion FROM USUARIOS AS U, ROLES AS R Where U.IDRol = R.ID ");
                if(id != "")
                {
                    datos.setearConsulta("Select U.ID, U.Nombre, U.Apellido, Nick, Dni, Telefono, Email, Pass, IDRol, urlImagenPerfil, R.ID as RolID, R.Nombre as RolDescripcion FROM USUARIOS AS U, ROLES AS R Where U.IDRol = R.ID AND U.ID = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarLectura();
                }

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nick = (string)datos.Lector["Nick"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Password = (string)datos.Lector["Pass"];
                    aux.Rol = new Rol();
                    aux.Rol.Id = (short)datos.Lector["RolID"];
                    aux.Rol.Descripcion = (string)datos.Lector["RolDescripcion"];

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

        public List<Usuario> listarConImagenes()
        {
            Imagen x;
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();
            List<Imagen> imagenes = new List<Imagen>();
            ImagenNegocio negocioImagen = new ImagenNegocio();
            try
            {
                datos.setearConsulta("");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    
                   // aux. = negocioImagen.listar(aux.ID);

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

        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            //int id = -1;
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, Nick, Dni, Telefono, Email, Pass, IDRol, urlImagenPerfil) VALUES (@nombre, @apellido, @nick, @dni, @telefono, @email, @pass, @IDRol, @urlImagenPerfil)");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@nick", nuevo.Nick);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@IDRol", nuevo.Rol.Id);
                datos.setearParametro("@urlImagenPerfil", (object)nuevo.ImagenPerfil ?? DBNull.Value);
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

        public Usuario buscar(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario aux = new Usuario();
            List<Imagen> imagenes = new List<Imagen>();
            ImagenNegocio negocioImagen = new ImagenNegocio();
            try
            {
                //datos.setearConsulta("SELECT TOP 1 * FROM ARTICULOS ORDER BY ID DESC");
                datos.setearConsulta("");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (int)datos.Lector["ID"];
                    

                    //aux.Imagenes = negocioImagen.listar(aux.ID);
                }
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

                datos.setearConsulta("SELECT TOP 1 * FROM USUARIOS ORDER BY ID DESC");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    id = (int)datos.Lector["ID"];
                }
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


        public List<Usuario> filtrar(string campo, string criterio, string filtro)
        {
            List<Usuario> list = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select U.ID, U.Nombre, U.Apellido, Nick, Dni, Telefono, Email, Pass, IDRol, urlImagenPerfil, R.ID as RolID, R.Nombre as RolDescripcion FROM USUARIOS AS U, ROLES AS R Where U.IDRol = R.ID AND ";

                if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "U.Nombre LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "U.Nombre LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "U.Nombre LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else if(campo == "Apellido")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "U.Apellido LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "U.Apellido LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "U.Apellido LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Email LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Email LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Email LIKE '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (long)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nick = (string)datos.Lector["Nick"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Password = (string)datos.Lector["Pass"];
                    aux.Rol = new Rol();
                    aux.Rol.Id = (short)datos.Lector["RolID"];
                    aux.Rol.Descripcion = (string)datos.Lector["RolDescripcion"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        aux.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    list.Add(aux);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from USUARIOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Usuario BuscarArticuloPorId(int idArticulo)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                return negocio.buscar(idArticulo.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT U.ID, U.Nombre, Apellido, Email, Nick, Telefono, Dni, urlImagenPerfil, IDRol, R.ID AS RolID, R.Nombre AS RolNombre FROM USUARIOS U INNER JOIN ROLES R ON U.IDRol = R.ID Where Email = @Email AND Pass = @Password");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password", usuario.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (long)datos.Lector["ID"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Nick = (string)datos.Lector["Nick"];
                    usuario.Telefono = (string)datos.Lector["Telefono"];
                    usuario.Dni = (string)datos.Lector["Dni"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    usuario.Rol = new Rol();
                    usuario.Rol.Id = (short)datos.Lector["RolID"];
                    usuario.Rol.Descripcion = (string)datos.Lector["RolNombre"];
                    return true;
                }
                else
                {
                    return false;
                }
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

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
    internal class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Id = (int)datos.Lector["ID"];

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

        public List<Usuario> listarConImagenes()
        {
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
            int id = -1;
            try
            {
                datos.setearConsulta("");
                //datos.setearParametro("@Codigo", nuevo.Codigo);
                
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
                datos.setearConsulta("");
                datos.setearParametro("@Codigo", aux.Id);

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
            return list;
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
    }
}

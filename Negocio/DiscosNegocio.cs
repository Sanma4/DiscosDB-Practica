using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Negocio;

namespace negocio
{
    public class DiscosNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server= .\\SQLEXPRESS; database= DISCOS_DB; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Id, D.Titulo, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, D.IdTipoEdicion, E.Descripcion Estilo, T.Descripcion Tipo from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo AND D.IdTipoEdicion = T.Id AND D.Activo = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    //if (!(lector["UrlImagen"] is DBNull)) 
                    //{ 
                        aux.UrlImagen = (string)lector["UrlImagenTapa"];
                    //}
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Tipo = new tipoDisco();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.Tipo.Id = (int)lector["IdTipoEdicion"];

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
                conexion.Close();
            }
        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into DISCOS (Titulo, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) values (@Titulo ,@CantidadCanciones, @UrlImagen,@IdEstilo, @IdTipo)");
                datos.setearParametros("@Titulo", nuevo.Titulo );
                datos.setearParametros("@CantidadCanciones", nuevo.CantidadCanciones);
                datos.setearParametros("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametros("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametros("@IdTipo", nuevo.Tipo.Id);
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

        public void modificar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("update DISCOS set Titulo = @titulo, CantidadCanciones = @cantidad, UrlImagenTapa = @img, IdEstilo = @estilo, IdTipoEdicion = @tipo Where Id = @id");
                
                datos.setearParametros("@titulo", nuevo.Titulo);
                datos.setearParametros("@cantidad", nuevo.CantidadCanciones);
                datos.setearParametros("@img", nuevo.UrlImagen);
                datos.setearParametros("@estilo", nuevo.Estilo.Id);
                datos.setearParametros("@tipo", nuevo.Tipo.Id);
                datos.setearParametros("@id", nuevo.Id);

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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos(); 
            try
            {
                datos.setearConsulta("delete from DISCOS where id = @id");
                datos.setearParametros("@id", id);
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
        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Activo = 0 Where Id = @id");
                datos.setearParametros("@id", id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace Negocio
{
    public class tipoDiscoNegocio
    {
         public List<tipoDisco> listar()
         {
            List<tipoDisco> lista = new List<tipoDisco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    tipoDisco aux = new tipoDisco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
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

            return lista; 
         }
    }
}

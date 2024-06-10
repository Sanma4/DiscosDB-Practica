using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Negocio
{
    public class estiloNegocio
    {
        public List<Estilo> listar()
        {
			List<Estilo> lista = new List<Estilo>();
			AccesoDatos Datos = new AccesoDatos();
			try
			{
				Datos.setearConsulta("Select Id, Descripcion from ESTILOS");
				Datos.ejecutarLector();
				while (Datos.Lector.Read())
				{
					Estilo aux = new Estilo();
					aux.Id = (int)Datos.Lector["Id"];
					aux.Descripcion = (string)Datos.Lector["Descripcion"];

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
				Datos.cerrarConexion();
			}
        }
    }
}

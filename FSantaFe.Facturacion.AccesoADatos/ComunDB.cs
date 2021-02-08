using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FSantaFe.Facturacion.AccesoADatos
{
    public class ComunDB
    {
        const string strConexion = @"Data Source=LAPTOP-RMHJKBUU;Initial Catalog=FacturacionFSantaFe;Integrated Security=True";

        //Metodo que sirve para hacer la conexion.
        private static SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(strConexion);
            connection.Open();
            return connection; 


        }

        //Metodo el cual sirve para crear comandos.
        public static SqlCommand Obtenercomando()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ObtenerConexion();
            return command;

        }

        //Metodo para guardar Cualquier transacccin de las entidades.
        public static int EjecutarComando(SqlCommand pComando)
        {
            int resultado = pComando.ExecuteNonQuery();
            pComando.Connection.Close();
            return resultado;

        }

        //Metodo sirve para leer las lineas de Datos de una consulta.
        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

    }
}

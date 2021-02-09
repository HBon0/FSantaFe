using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSantaFe.Facturacion.EntidadesDeNegocio;
using System.Data.SqlClient;

namespace FSantaFe.Facturacion.AccesoADatos
{
    public class TipoMaterialDAL
    {
        //Metodo que sirve para guardar Registros en la DB.
        public static int Guardar(TipoMaterial pTipoMaterial)
        {
            string consulta = @"INSERT INTO TipoMaterial(IdEstado, Nombre) VALUES(@IdEstado, @Nombre)";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEstado", pTipoMaterial.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pTipoMaterial.Nombre);
            return ComunDB.EjecutarComando(comando);
        }

        //Metodo que sirve para Modificar Registros.
        public static int Modificar(TipoMaterial pTipoMaterial)
        {
            string consulta = @"UPDATE TipoMaterial SET IdEstado = @IdEstado, Nombre = @Nombre Where Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue(@"Id", pTipoMaterial.Id);
            comando.Parameters.AddWithValue(@"IdEstado", pTipoMaterial.IdEstado);
            comando.Parameters.AddWithValue(@"Nombre", pTipoMaterial.Nombre);
            return ComunDB.EjecutarComando(comando);
        }

        //Metodo que sirve para Eliminar un registro.
        public static int Eliminar(TipoMaterial pTipoMaterial)
        {
            string consulta = @"DELETE FROM TipoMaterial WHERE Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pTipoMaterial.Id);
            return ComunDB.EjecutarComando(comando);
        }



        //Metodo para listar los registros.
        public static List<TipoMaterial> ObtenerTodos()
        {
            string consulta = @"SELECT TOP 500 t.Id, t.IdEstado, t.Nombre FROM TipoMaterial t";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<TipoMaterial> ListatMaterial = new List<TipoMaterial>();
            while (reader.Read())
            {
                TipoMaterial tipoMaterial = new TipoMaterial();
                tipoMaterial.Id = reader.GetInt16(0);
                tipoMaterial.IdEstado = reader.GetByte(1);
                tipoMaterial.Nombre = reader.GetString(2);
                ListatMaterial.Add(tipoMaterial);
            }
            return ListatMaterial;
        }

        //Metodo para Buscar mediante Id.
        public static TipoMaterial BuscarPorId(Int16 pTipoMaterial)
        {
            string consulta = @"SELECT t.Id, t.IdEstado, t.Nombre FROM TipoMaterial t WHERE t.Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pTipoMaterial);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            TipoMaterial tipoMaterial = new TipoMaterial();
            while (reader.Read())
            {
                tipoMaterial.Id = reader.GetInt16(0);
                tipoMaterial.IdEstado = reader.GetByte(1);
                tipoMaterial.Nombre = reader.GetString(2);
            }
            return tipoMaterial;
        }


        //Metodo para Observar los Registros Habilitados.
        public static List<TipoMaterial> ObtenerHabilitados()
        {
            string consulta = @"SELECT TOP 500 t.Id, t.IdEstado, t.Nombre FROM TipoMaterial t WHERE IdEstado = 1";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<TipoMaterial> listaMaterial = new List<TipoMaterial>();
            while (reader.Read())
            {
                TipoMaterial tipoMaterial = new TipoMaterial();
                tipoMaterial.Id = reader.GetInt16(0);
                tipoMaterial.IdEstado = reader.GetByte(1);
                tipoMaterial.Nombre = reader.GetString(2);
                listaMaterial.Add(tipoMaterial);
            }
            return listaMaterial;
        }

        public static List<TipoMaterial> Buscar(TipoMaterial ptipoMaterial)
        {
            string consulta = @"SELECT TOP 500 t.Id, t.IdEstado, t.Nombre FROM TipoMaterial t";
            string whereSql = " ";  //Sirve para agregar condiciones a la consulta segun los campos que deseémos buscar
            byte contadorDeCampos = 0; //Sirve para saber si se debe agregar " AND " a la consulta
            SqlCommand comando = ComunDB.Obtenercomando();

            //Agrega condiciones a la consulta para obtener los registros filtrados por los campos de busqueda enviados de la UI
            if (ptipoMaterial.IdEstado > 0) //verifica que la propiedad "IdEstado" tenga información para buscar
            {
                if (contadorDeCampos > 0)
                {
                    whereSql += " AND "; //"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado = @IdEstado"; 
                }
                contadorDeCampos++; //Incrementa el contador de campos mas 1
                whereSql += " IdEstado = @IdEstado";
                comando.Parameters.AddWithValue("@IdEstado", ptipoMaterial.IdEstado);
            }


            //verifica si se agrega el campo IdEstado como filtro de busqueda (Buscar por Estado)
            if (ptipoMaterial.Nombre != null && ptipoMaterial.Nombre.Trim().Length > 0) //verifica que la propiedad "Nombre" tenga informacion para buscar
            {
                if (contadorDeCampos > 0)
                {
                    whereSql += " AND "; //"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado = @IdEstado AND Nombre LIKE @Nombre";
                }
                contadorDeCampos++; //Incrementa el contador de campos mas 1
                whereSql += " Nombre LIKE @Nombre ";
                comando.Parameters.AddWithValue("@Nombre", '%' + ptipoMaterial.Nombre + '%');
            }


            if (whereSql.Trim().Length > 0) //Verifica si l variable "whereSql" contiene texto
            {
                whereSql = " WHERE " + whereSql; //Agrega la clausula where a la consulta si "whereSql" No viene vacia 
            }

            comando.CommandText = consulta + whereSql; //Agrega las dos partes de la consulta al comando
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando); //Ejecuta el comando mediante la "ComunDB"
            List<TipoMaterial> listaTipoMaterial = new List<TipoMaterial>(); //Crea una lista para depositar los datos mediante el "while" que sigue a continuacion

            while (reader.Read()) //Lee cada item del reader
            {
                TipoMaterial tipoMaterial = new TipoMaterial(); //Crea una instancia temporal para alojar los datos del reader
                tipoMaterial.Id = reader.GetInt16(0);
                tipoMaterial.IdEstado = reader.GetByte(1);
                tipoMaterial.Nombre = reader.GetString(2);
                listaTipoMaterial.Add(tipoMaterial); //Agrega el objeto "cargo" a la lista
            }
            comando.Connection.Dispose();
            return listaTipoMaterial; //retorna la lista de Cargos en el caso que hayan datos coincidentes
        }

    }
}

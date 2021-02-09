using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSantaFe.Facturacion.EntidadesDeNegocio;

namespace FSantaFe.Facturacion.AccesoADatos
{
    public class CargoDAL
    {

        //Metodo que sirve para guardar Registros en la DB.
        public static int Guardar(Cargo pCargo)
        {
            string consulta = @"INSERT INTO Cargo(IdEstado, Nombre) VALUES(@IdEstado, @Nombre)";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pCargo.Nombre);
            return ComunDB.EjecutarComando(comando);
        }

        //Metodo que sirve para Modificar Registros.
        public static int Modificar(Cargo pCargo)
        {
            string consulta = @"UPDATE Cargo SET IdEstado = @IdEstado, Nombre = @Nombre Where Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue(@"Id", pCargo.Id);
            comando.Parameters.AddWithValue(@"IdEstado", pCargo.IdEstado);
            comando.Parameters.AddWithValue(@"Nombre", pCargo.Nombre);
            return ComunDB.EjecutarComando(comando);
        }

        //Metodo que sirve para Eliminar un registro.
        public static int Eliminar(Cargo pCargo)
        {
            string consulta = @"DELETE FROM Cargo WHERE Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pCargo.Id);
            return ComunDB.EjecutarComando(comando);
        }

        

        //Metodo para listar los registros.
        public static List<Cargo> ObtenerTodos()
        {
            string consulta = @"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Cargo> ListaCargos = new List<Cargo>();
            while (reader.Read())
            {
                Cargo cargo = new Cargo();
                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);
                ListaCargos.Add(cargo);
            }
            return ListaCargos;
        }

        //Metodo para Buscar mediante Id.
        public static Cargo BuscarPorId(byte pId)
        {
            string consulta = @"SELECT c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE c.Id = @Id";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Cargo cargo = new Cargo();
            while (reader.Read())
            {
                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);
            }
            return cargo;
        }


        //Metodo para Observar los Registros Habilitados.
        public static List<Cargo> ObtenerHabilitados()
        {
            string consulta = @"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado = 1";
            SqlCommand comando = ComunDB.Obtenercomando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Cargo> listaCargos = new List<Cargo>();
            while (reader.Read())
            {
                Cargo cargo = new Cargo();
                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);
                listaCargos.Add(cargo);
            }
            return listaCargos;
        }

        public static List<Cargo> Buscar(Cargo pCargo)
        {
            string consulta = @"SELECT TOP 500 c.Id, IdEstado, c.Nombre FROM Cargo c";
            string whereSql = " ";  //Sirve para agregar condiciones a la consulta segun los campos que deseémos buscar
            byte contadorDeCampos = 0; //Sirve para saber si se debe agregar " AND " a la consulta
            SqlCommand comando = ComunDB.Obtenercomando();

            //Agrega condiciones a la consulta para obtener los registros filtrados por los campos de busqueda enviados de la UI
            if (pCargo.IdEstado > 0) //verifica que la propiedad "IdEstado" tenga información para buscar
            { 
                if (contadorDeCampos > 0)
                {
                    whereSql += " AND "; //"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado = @IdEstado"; 
                }
                contadorDeCampos++; //Incrementa el contador de campos mas 1
                whereSql += " IdEstado = @IdEstado";
                comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            }


            //verifica si se agrega el campo IdEstado como filtro de busqueda (Buscar por Estado)
            if (pCargo.Nombre != null && pCargo.Nombre.Trim().Length > 0) //verifica que la propiedad "Nombre" tenga informacion para buscar
            {
                if (contadorDeCampos > 0) 
                {
                    whereSql += " AND "; //"SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado = @IdEstado AND Nombre LIKE @Nombre";
                }
                contadorDeCampos++; //Incrementa el contador de campos mas 1
                whereSql += " Nombre LIKE @Nombre ";
                comando.Parameters.AddWithValue("@Nombre", '%' + pCargo.Nombre + '%'); 
            }


            if (whereSql.Trim().Length > 0) //Verifica si l variable "whereSql" contiene texto
            {
                whereSql = " WHERE " + whereSql; //Agrega la clausula where a la consulta si "whereSql" No viene vacia 
            }

            comando.CommandText = consulta + whereSql; //Agrega las dos partes de la consulta al comando
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando); //Ejecuta el comando mediante la "ComunDB"
            List<Cargo> listaCargos = new List<Cargo>(); //Crea una lista para depositar los datos mediante el "while" que sigue a continuacion

            while (reader.Read()) //Lee cada item del reader
            {
                Cargo cargo = new Cargo(); //Crea una instancia temporal para alojar los datos del reader
                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);
                listaCargos.Add(cargo); //Agrega el objeto "cargo" a la lista
            }
            comando.Connection.Dispose();
            return listaCargos; //retorna la lista de Cargos en el caso que hayan datos coincidentes
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSantaFe.Facturacion.AccesoADatos;
using FSantaFe.Facturacion.EntidadesDeNegocio;


namespace FSantaFe.Facturacion.LogicaDeNegocio
{
    public class EstadoBL
    {
        //Metodo intermedio, es utilisado para llamar y
        //devolver la informacion del metodo Guardar
        //de la clase EstadoDAL ubicado en Acceso a Datos.
        public static int Guardar(Estado pEstado)
        {
            return EstadoDAL.Guardar(pEstado);
        }

        //Metodo intermedio, es utilisado para llamar y
        //devolver la informacion del metodo Modificar 
        //de la clase EstadoDAL ubicado en Acceso a Datos.
        public static int Modificar(Estado pEstado)
        {
            return EstadoDAL.Modificar(pEstado);
        }

        //Metodo intermedio, es utilisado para llamar y
        //devolver la informacion del metodo Eliminar
        //de la clase EstadoDAL ubicado en Acceso a Datos.
        public static int Eliminar(Estado pEstado)
        {
            return EstadoDAL.Eliminar(pEstado);
        }

        //Metodo intermedio, es utilisado para llamar y
        //devolver la informacion del metodo ObtenerTodos 
        //de la clase EstadoDAL ubicado en Acceso a Datos.
        public static List<Estado> ObtenerTodos()
        {
            return EstadoDAL.ObtenerTodos();
        }

        //Metodo intermedio, es utilisado para llamar y
        //devolver la informacion del metodo BuscarPorId 
        //de la clase EstadoDAL ubicado en Acceso a Datos.
        public static Estado BuscarPorId(byte pId)
        {
            return EstadoDAL.BuscarPorId(pId);
        }


    }
}

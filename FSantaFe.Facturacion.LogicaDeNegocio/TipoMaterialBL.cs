using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSantaFe.Facturacion.AccesoADatos;
using FSantaFe.Facturacion.EntidadesDeNegocio;

namespace FSantaFe.Facturacion.LogicaDeNegocio
{
    public class TipoMaterialBL
    {
        public static int Guardar(TipoMaterial ptipoMaterial)
        {
            return TipoMaterialDAL.Guardar(ptipoMaterial);
        }

        public static int Modificar(TipoMaterial ptipoMaterial)
        {
            return TipoMaterialDAL.Modificar(ptipoMaterial);
        }

        public static int Eliminar(TipoMaterial ptipoMaterial)
        {
            return TipoMaterialDAL.Eliminar(ptipoMaterial);
        }

        public static List<TipoMaterial> ObtenerTodos()
        {
            return TipoMaterialDAL.ObtenerTodos();
        }

        public static TipoMaterial BuscarPorId(Int16 pId)
        {
            return TipoMaterialDAL.BuscarPorId(pId);
        }

        public static List<TipoMaterial> ObtenerHabilitados()
        {
            return TipoMaterialDAL.ObtenerHabilitados();
        }

        public static List<TipoMaterial> Buscar(TipoMaterial ptipoMaterial)
        {
            return TipoMaterialDAL.Buscar(ptipoMaterial);
        }
    }
}

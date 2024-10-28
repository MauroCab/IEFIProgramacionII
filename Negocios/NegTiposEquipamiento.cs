using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegTiposEquipamiento
    {
        DatosTiposEquipamiento objDatosTiposEquipamiento = new DatosTiposEquipamiento();

        public int abmTiposEquipamiento(string accion, TipoEquipamiento objTipoEquipamiento)
        {
            return objDatosTiposEquipamiento.abmTiposEquipamiento(accion, objTipoEquipamiento);
        }
        public DataSet listadoTiposEquipamiento(string cual)
        {
            return objDatosTiposEquipamiento.listadoTiposEquipamiento(cual);
        }
    }
}

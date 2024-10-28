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
    public class NegItems
    {
        DatosItems objDatosItems = new DatosItems();

        public int abmItems(string accion, Item objItem)
        {
            return objDatosItems.abmItems(accion, objItem);
        }
        public DataSet listadoItems(string cual)
        {
            return objDatosItems.listadoItems(cual);
        }
    }
}

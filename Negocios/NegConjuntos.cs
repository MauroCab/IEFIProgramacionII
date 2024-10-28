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
    public class NegConjuntos
    {
        DatosConjuntos objDatosConjuntos = new DatosConjuntos();

        public int abmConjuntos(string accion, Conjunto objConjunto)
        {
            return objDatosConjuntos.abmConjuntos(accion, objConjunto);
        }
        public DataSet listadoConjuntos(string cual)
        {
            return objDatosConjuntos.listadoConjuntos(cual);
        }
    }
}

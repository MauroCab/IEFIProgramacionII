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
    public class NegPersonajes
    {
        DatosPersonajes objDatosPersonajes = new DatosPersonajes();

        public int abmPersonajes(string accion, Personaje objPersonaje)
        {
            return objDatosPersonajes.abmPersonajes(accion, objPersonaje);
        }
        public DataSet listadoPersonajes(string cual)
        {
            return objDatosPersonajes.listadoPersonajes(cual);
        }
    }
}

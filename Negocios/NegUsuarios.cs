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
    public class NegUsuarios
    {
        DatosUsuarios objDatosUsuarios = new DatosUsuarios();

        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            return objDatosUsuarios.abmUsuarios(accion, objUsuario);
        }
        public DataSet listadoUsuarios(string cual)
        {
            return objDatosUsuarios.listadoUsuarios(cual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;
using System.Data.SqlClient;

namespace Negocios
{
    public class NegUsuarios
    {
        DatosUsuarios objDatosUsuarios = new DatosUsuarios();

        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            return objDatosUsuarios.abmUsuarios(accion, objUsuario);
        }
        
        public int BuscarUsuario(string email, string contrasena)
        {
            return objDatosUsuarios.BuscarUsuario(email, contrasena);
        }

        public int BuscarUsuario(string email)
        {
            return objDatosUsuarios.BuscarUsuario(email);
        }

        public Usuario BuscarUsuarioById(int id)
        {
            return objDatosUsuarios.BuscarUsuarioById(id);
        }
        public bool EmailExiste(string email)
        {
            return objDatosUsuarios.EmailExiste(email);
        }
        public string GetContrasena(string email)
        {
            return objDatosUsuarios.GetContrasena(email);
        }
    }
}

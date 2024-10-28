using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        #region atributos
        private int id;
        private string nombreUsuario;
        private string email;
        private string contrasena;
        private List<Personaje> personajes;
        #endregion

        #region Constructor
        public Usuario()
        {

        }
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NombreUsuario 
        { get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { Contrasena = value; }
        }

        public List<Personaje> Personajes
        {
            get { return personajes; }
            set { personajes = value; }
        }
        #endregion

    }
}

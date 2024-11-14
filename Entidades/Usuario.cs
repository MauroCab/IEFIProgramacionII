﻿using System;
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
        private string nombre;
        private string email;
        private string contrasena;
        #endregion

        #region Constructores
        public Usuario()
        {

        }

        public Usuario(int id, string username)
        {
            Id = id;
            Nombre = username;
            Email = "";
            Contrasena = "";
        }
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        { get { return nombre; }
            set { nombre = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Contrasena
        {
            get { return "*******"; }
            set { contrasena = value; }
        }

        #endregion

    }
}

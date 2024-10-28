using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Conjunto
    {
        /*
		-Id_Conjunto
		-Nombre
		-EfectoConjunto
        */
        #region atributos
        private int id;
        private string nombre;
        private string efectoConjunto;
        #endregion

        #region Constructor
        public Conjunto()
        {
            
        }
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set {  id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set {  nombre = value; }
        }
        public string EfectoConjunto
        {
            get { return efectoConjunto;}
            set {  efectoConjunto = value;}
        }
        #endregion
    }
}

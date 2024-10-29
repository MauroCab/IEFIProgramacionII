using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoEquipamiento
    {
        /*
		-Id_TipoEquipamiento
		-Nombre
        */
        #region atributos
        private int id;
        private string nombre;
        #endregion

        #region Constructor
        public TipoEquipamiento()
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
        #endregion
    }Ti
}

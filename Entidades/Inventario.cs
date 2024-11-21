using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventario
    {
        #region atributos
        private int id;
        private Personaje personaje;
        private Item item;
        private int cantidad;
        private bool equipado;
        #endregion


        #region Constructor
        public Inventario()
        {

        }

        
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Personaje Personaje
        {
            get { return personaje; }
            set { personaje = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public bool Equipado
        {
            get { return equipado; }
            set { equipado = value; }
        }
        #endregion

    }
}

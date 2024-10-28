using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Item
    {
        /*-Nombre
	    -Id_Ítem
	    -Id_Conjunto (nullable) (foránea)
	    -Id_TipoEquipamiento
	    -Daño (probablemente solo los tipo “Arma” tengan un valor distinto de cero)
        -Defensa (que proporciona el ítem)
        -Evasión (que proporciona el ítem)
        -Energía (que proporciona el ítem)
        -Salud (que proporciona el ítem)
        -A Dos Manos (solo aplicable a tipo Arma, y si está equipado el “EscudoEq” del personaje es siempre null) (No es un estado de “si está a dos manos o no”, es si el arma es un mandoble: espadón, hacha de guerra, etc. Pero no le pongo mandoble a la propiedad porque se suele entender como “espadón” directamente)*
        -Durabilidad
        -Precio (no hace nada, pero ahí está para más inmersión)*
        -Rareza (a lo Diablo (o MMO), osea: común, infrecuente, épico, legendario, tampoco hace nada)*.
        - Efecto/Pasiva (es solo texto de un efecto, no hace nada, pero el punto es listarlo en la tabla de efectos del character nada más)*
	    -Equipado (bool) (si el item del inventario está equipado o no xd)
         */
        #region atributos
        private int id;
        private int idTipoEquipamiento;
        private int? idConjunto;
        private string nombre;
        private int dano;
        private int itemDefensa;
        private int itemEvasion;
        private int itemEnergia;
        private int itemSalud;
        private bool aDosManos;
        private int durabilidad;
        private int precio;
        private string rareza;
        private string efecto;
        private bool equipado;
        #endregion

        #region Constructor
        public Item()
        {
            
        }
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdTipoEquipamiento
        {
            get { return idTipoEquipamiento; }
            set { idTipoEquipamiento = value; }
        }
        public int? IdConjunto
        {
            get { return idConjunto; }
            set { idConjunto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Dano
        {
            get { return dano; }
            set { dano = value; }
        }
        public int ItemDefensa
        {
            get { return itemDefensa; }
            set { itemDefensa = value; }
        }
        public int ItemEvasion
        {
            get { return itemEvasion; }
            set { itemEvasion = value; }
        }
        public int ItemEnergia
        {
            get {return itemEnergia; }
            set { itemEnergia = value; }
        }   
        public int ItemSalud
        {
            get { return itemSalud; }
            set { itemSalud = value; }
        }
        public bool ADosManos
        {
            get { return aDosManos; }
            set { aDosManos = value; }
        }
        public int Durabilidad
        {
            get { return durabilidad; }
            set { durabilidad = value; }
        }
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Rareza
        {
            get { return rareza; }
            set { rareza = value; }
        }
        public string Efecto
        {
            get { return efecto; }
            set { efecto = value; }
        }
        public bool Equipado
        {
            get { return equipado; }
            set { equipado = value; }
        }
        #endregion
    }
}

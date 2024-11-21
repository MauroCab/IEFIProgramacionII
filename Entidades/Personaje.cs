using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personaje
    {
		/*
			Personaje:
		-Id_Personaje
		-Nombre
		-Id_Cuenta
		-Nivel
		-Clase
		-Salud
		-Energía
		-Inventario[items]
		-Ataque (total)
		-Defensa
		-Evasión
		-Casco Eq.: Objeto, clase: ítem, Tipo:[Nombre]
		-Pant Eq.
		-Guantes Eq.
		-Armadura Eq.
		-Arma Eq.
		-Escudo Eq.
		-Efectos[]
		-Fecha_Creacion

         */
		#region atributos
		private int id;
		private string nombre;
		private int idUsuario;
		private int nivel;
		private string clase;
		private int salud;
		private int energia;
		private int ataque;
		private int defensa;
		private int evasion;
		private Item cascoEq;
		private Item pantEq;
		private Item guantesEq;
		private Item armaduraEq;
		private Item armaEq;
		private Item escudoEq;
		private List<Item> inventario;
		private List<string> efectos;
		private DateTime fechaCreacion;
        #endregion

        #region Constructor
        public Personaje()
        {
            /*Item casco = new Item();
            Item pant = new Item();
            Item guantes = new Item();
            Item armadura = new Item();
            Item arma = new Item();
            Item escudo = new Item();
            Item item = new Item();*/
			cascoEq = new Item();
			pantEq = new Item();
			guantesEq = new Item();
			armaduraEq = new Item();
			armaEq = new Item();
			escudoEq = new Item();
			inventario = new List<Item>();
        }
        #endregion

        #region propiedades/encapsulamiento
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public int IdUsuario
		{
			get { return idUsuario;}
			set { idUsuario = value; }
		}
		public int Nivel
		{
			get { return nivel; }
			set { nivel = value; }
		}
		public string Clase
		{
			get { return clase; }
			set { clase = value; }
		}
		public int Salud
		{
			get { return salud; }
			set { salud = value; }
		}
        public int Energia
        {
            get { return energia; }
            set { energia = value; }
        }
        public int Ataque
        {
            get { return ataque; }
            set { ataque = value; }
        }
        public int Defensa
        {
            get { return defensa; }
            set { defensa = value; }
        }
        public int Evasion
        {
            get { return evasion; }
            set { evasion = value; }
        }
		public Item CascoEq
		{
			get { return cascoEq; }
			set { cascoEq = value; }
		}
        public Item PantEq
        {
            get { return pantEq; }
            set { pantEq = value; }
        }
        public Item GuantesEq
        {
            get { return guantesEq; }
            set { guantesEq = value; }
        }
        public Item ArmaduraEq
        {
            get { return armaduraEq; }
            set { armaduraEq = value; }
        }
        public Item ArmaEq
        {
            get { return armaEq; }
            set { armaEq = value; }
        }
        public Item EscudoEq
        {
            get { return escudoEq; }
            set { escudoEq = value; }
        }
        public List<Item> Inventario
        {
            get { return inventario; }
            set { inventario = value; }
        }
        public List<string> Efectos
		{
			get { return efectos; }
			set { efectos = value; }
		}
		public DateTime FechaCreacion
		{
			get { return fechaCreacion; }
			set {  fechaCreacion = value; }
		}
        #endregion
    }
}

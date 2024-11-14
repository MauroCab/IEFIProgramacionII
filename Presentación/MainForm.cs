using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class RPGCMForm : Form
    {
        public RPGCMForm()
        {
            InitializeComponent();
            //TabsDiseño.ItemSize = new System.Drawing.Size(0, 1);
            TabsDiseño.Dock = DockStyle.Fill;
        }

        
        private Usuario UsuarioLogueado { get; set; }


        void IForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IngresarForm IForm = sender as IngresarForm;
            //Recuperar el valor de propiedades definidas en Form2
            int IdABuscar = IForm.UserId;
            NegUsuarios objNegUsuarios = new NegUsuarios();
            
            //Codigo que hace Get del usuario por su id
            UsuarioLogueado = objNegUsuarios.BuscarUsuarioById(IdABuscar);
            

            if (UsuarioLogueado != null)
            {
                lblUsername.Text = UsuarioLogueado.Nombre;
                TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabSelect"];
            }
            else
            {
                MessageBox.Show("No se encontró el usuario.");
            }
        }

        bool ExisteCuenta;

        #region Botones de Inicio
        private void btRegistro_Click(object sender, EventArgs e)
        {
            ExisteCuenta = false; 
            IngresarForm IForm = new IngresarForm(ExisteCuenta);
            IForm.FormClosed += IForm_FormClosed;
            IForm.ShowDialog();
            IForm.Focus();
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            ExisteCuenta = true;
            IngresarForm IForm = new IngresarForm(ExisteCuenta);
            IForm.FormClosed += IForm_FormClosed;
            IForm.ShowDialog();
            IForm.Focus();
        }
        #endregion 

        //me cansé de borrar metodos
        #region metodos creados sin querer
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabCreación_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblNivelInicial_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabPJItems_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btCrearPersonaje_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabCreacion"];
        }

       
    }
    
}

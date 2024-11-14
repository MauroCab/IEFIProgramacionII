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

        private NegUsuarios objNegUsuarios;
        private Usuario UsuarioLogueado;
        void formHijo_FormClosed(object sender, FormClosedEventArgs e)
        {
            IngresarForm formHijo = sender as IngresarForm;
            //Recuperar el valor de propiedades definidas en Form2
            int IdABuscar = formHijo.UserId;

            UsuarioLogueado = objNegUsuarios.BuscarUsuarioById(IdABuscar);

            //Codigo que haga Get del usuario por su Username
            lblUsername.Text = UsuarioLogueado.Nombre;
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabSelect"];
            
        }

        bool ExisteCuenta;

        #region Botones de Inicio
        private void btRegistro_Click(object sender, EventArgs e)
        {
            ExisteCuenta = false; 
            IngresarForm IForm = new IngresarForm(ExisteCuenta);
            IForm.ShowDialog();
            IForm.Focus();
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            ExisteCuenta = true; 
            IngresarForm IForm = new IngresarForm(ExisteCuenta);
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

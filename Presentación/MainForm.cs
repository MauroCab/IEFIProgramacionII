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

        bool ExisteCuenta;

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

        private void button1_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabSelect"];
        }

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

        #endregion

        private void btCrearPersonaje_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabCreacion"];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}

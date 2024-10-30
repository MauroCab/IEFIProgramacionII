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

        private void panelIngreso_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

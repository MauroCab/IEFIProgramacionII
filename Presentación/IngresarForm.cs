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
    public partial class IngresarForm : Form
    {
        public IngresarForm(bool existeCuenta)
        {
            InitializeComponent();
            bool ExisteCuenta = existeCuenta;
            if (ExisteCuenta)
            {
                tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabIniciarSesion"];
            }
            
        }

        private void linkLogIn_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabIniciarSesion"];
        }

        private void linkSignUp_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabRegistrarse"];
        }
    }
}

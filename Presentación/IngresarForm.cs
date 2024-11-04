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

            username = "";
        }

        public string username { get; set; }

        
        private void linkLogIn_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabIniciarSesion"];
        }

        private void linkSignUp_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabRegistrarse"];
        }

        private void btAceptarSU_Click(object sender, EventArgs e)
        {
            #region Validaciones
            bool CamposValidados = true;
            if (string.IsNullOrEmpty(tbxEmailSU.Text) || 
                string.IsNullOrEmpty(tbxNombreUsuario.Text) || 
                string.IsNullOrEmpty(tbxContrasenaSU.Text) || 
                string.IsNullOrEmpty(tbxContrasena2.Text))
            {
                MessageBox.Show("Uno o más campos obligatorios sin llenar");
                CamposValidados = false;
            }

            if(tbxContrasenaSU.Text != tbxContrasena2.Text)
            {
                MessageBox.Show("Contraseña repetida incorrecta");
                CamposValidados = false;
            }

            if (!tbxEmailSU.Text.Contains("@"))
            {
                MessageBox.Show("Correo electrónico especificado no válido");
                CamposValidados = false;
            }
            #endregion 

            //[Código para insertar el email, el username y la contraseña en la base de datos]

            ValidarEIngresar(CamposValidados, tbxEmailLI.Text, tbxContrasenaLI.Text);
        }

        private void btAceptarLI_Click(object sender, EventArgs e)
        {
            #region Validaciones
            bool CamposValidados = true;

            if (string.IsNullOrEmpty(tbxEmailLI.Text) ||                
                string.IsNullOrEmpty(tbxContrasenaLI.Text))
            {
                MessageBox.Show("Rellene todos los campos");
                CamposValidados = false;
            }

            if (!tbxEmailSU.Text.Contains("@"))
            {
                MessageBox.Show("Correo electrónico especificado no válido");
                CamposValidados = false;
            }

            //[Código para buscar en la base de datos la contraseña del mail especificado
            //y comparar si es la misma que se guardó]

            #endregion

            ValidarEIngresar(CamposValidados, tbxEmailLI.Text, tbxContrasenaLI.Text);
        }

        private void ValidarEIngresar(bool validacionCorrecta, string selectEmail, string selectContrasena)
        {
            if (validacionCorrecta)
            {
                //[Código que hace select de los datos de usuario
                //concordantes con los datos recién ingresados (mail y contraseña) y devuelve
                //el nombre usuario (resultado) el cual va a ser guardado en la propiedad username,
                //perteneciente a la clase]

                //username = resultado;
                this.Close();

            }
        }

        
        
    }
}

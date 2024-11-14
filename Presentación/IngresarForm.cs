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

            UserId = 0;
        }

        #region Propiedades
        /// <summary>
        /// Es el dato que despues le paso al MainForm para hacer select y trabajar con los datos del usuario con esta Id
        /// </summary>
        public int UserId { get; set; }
        public NegUsuarios objNegUsuario = new NegUsuarios();
        public Usuario objEntUsuario = new Usuario();
        #endregion 

        #region Metodos decorativos
        private void linkLogIn_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabIniciarSesion"];
        }

        private void linkSignUp_Click(object sender, EventArgs e)
        {
            tabsIngresar.SelectedTab = tabsIngresar.TabPages["tabRegistrarse"];
        }
        #endregion

        #region Botones de Aceptar
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

            if(CamposValidados)
            {
                //[Código para insertar el usuario en la base de datos]
                CrearUsuario();
                bool pepe = EnvioIdConValidacionLogIn(CamposValidados, tbxEmailSU.Text, tbxContrasenaSU.Text);
                MessageBox.Show("Cuenta creada correctamente", "Usuario Cargado", MessageBoxButtons.OK);
                this.Close();
            }
           
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

            if (!tbxEmailLI.Text.Contains("@"))
            {
                MessageBox.Show("Correo electrónico especificado no válido");
                CamposValidados = false;
            }

            //[Código para buscar en la base de datos la contraseña del mail especificado
            //y comparar si es la misma que se guardó]

            #endregion

            if (CamposValidados)
            {
                bool pepe = EnvioIdConValidacionLogIn(CamposValidados, tbxEmailLI.Text, tbxContrasenaLI.Text);
                
                if(pepe)
                this.Close();
            }
            
        }
        #endregion

        #region Validación tipo Búsqueda
        /// <summary>
        /// Hace que la propiedad UserId perteneciente al IngresarForm tenga el valor del id
        /// del usuario coincidente con el mail y la contraseña ingresadas, siempre y cuando haya un usuario
        /// coincidente, en caso de que no, devuelve un MessageBox con el error
        /// </summary>
        /// <param name="validacionCorrecta"> Las anteriores validaciones fueron superadas?</param>
        /// <param name="selectEmail"> Mail Ingresado </param>
        /// <param name="selectContrasena"> Contraseña Ingresada </param>
        /// <returns>Un bool que determina si en la BD existe un usuario con mail y contraseña coincidente, esta parte solo es util con el login, 
        /// al crear usuario obviamente que el valor va a estar, pero tengo que usar el metodo igual,
        /// para llenar UserId con el id, su unico uso para determinar si se deberia cerrar el form al terminar </returns>
        private bool EnvioIdConValidacionLogIn(bool validacionCorrecta, string selectEmail, string selectContrasena)
        {
            if (validacionCorrecta)
            {
                int IdResultado = objNegUsuario.BuscarUsuario(selectEmail, selectContrasena);
                if (IdResultado != 0)
                {
                    UserId = IdResultado;
                    return true;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK);
                    return false;
                }

            }
            else
                return false;
        }
        #endregion 

        #region Creación de Usuario
        private void CargaDeDatos()
        {
            objEntUsuario.Id = 1;
            objEntUsuario.Email = tbxEmailSU.Text;
            objEntUsuario.Nombre = tbxNombreUsuario.Text;
            objEntUsuario.Contrasena = tbxContrasenaSU.Text;
        }

        private void CrearUsuario()
        {
            int nGrabados = -1;
            //llamo al m�todo que carga los datos del objeto
            CargaDeDatos();
            nGrabados = objNegUsuario.abmUsuarios("Alta", objEntUsuario); //invoco a la capa de negocio
            if (nGrabados == -1)
            {
                MessageBox.Show("No pudo a�adir el usuario en el sistema");
                
            }
            
        }
        #endregion

    }
}

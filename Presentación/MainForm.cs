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
using static System.Net.Mime.MediaTypeNames;

namespace Presentación
{
    public partial class RPGCMForm : Form
    {
        public RPGCMForm()
        {
            InitializeComponent();
            //TabsDiseño.ItemSize = new System.Drawing.Size(0, 1);
            TabsDiseño.Dock = DockStyle.Fill;
            panelUpdate.Hide();
        }

        #region Propiedades
        private Usuario UsuarioLogueado { get; set; }
        public NegUsuarios objNegUsuario = new NegUsuarios();
        public Usuario objEntUsuario = new Usuario();
        #endregion
        void IForm_Cerrado(object sender, EventArgs e)
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
            IForm.EventoCerrar += IForm_Cerrado;
            IForm.ShowDialog();
            IForm.Focus();
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            ExisteCuenta = true;
            IngresarForm IForm = new IngresarForm(ExisteCuenta);
            IForm.EventoCerrar += IForm_Cerrado;
            IForm.ShowDialog();
            IForm.Focus();
        }
        #endregion

        #region Opciones de Usuario

        bool QCC = false;
        bool QCNU = false;
        bool QCE = false;
        private void BorrarUsuario()
        {
            int nGrabados = -1;
            
            nGrabados = objNegUsuario.abmUsuarios("Baja", UsuarioLogueado); //invoco a la capa de negocio
            if (nGrabados == -1)
            {
                MessageBox.Show("No pudo borrar el usuario");

            }
            else
            {
                MessageBox.Show("Usuario eliminado correctamente");
                TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabInicio"];
                UsuarioLogueado = null;
            }
            QuiereBorrar = false;

        }

        private Usuario CargarDatosNuevos(bool QuiereCambiarContrasena, 
                                            bool QuiereCambiarNombreUsuario,
                                            bool QuiereCambiarEmail)
        {
            Usuario usuario = new Usuario();
            usuario.Id = UsuarioLogueado.Id;

            #region Carga de Datos
            if (QuiereCambiarNombreUsuario)
                usuario.Nombre = tbxUpdateUsername.Text;
            else
                usuario.Nombre = UsuarioLogueado.Nombre;

            if (QuiereCambiarEmail)
                usuario.Email = tbxUpdateEmail.Text;
            else
                usuario.Email = UsuarioLogueado.Email;

            if (QuiereCambiarContrasena)
                usuario.Contrasena = tbxUpdateContrasena2.Text;
            else
                usuario.Contrasena = UsuarioLogueado.Contrasena;
            #endregion 

            return usuario;

        }


        private void ModificarDatosUsuario(bool QCC, bool QCNU, bool QCE)
        {
            int nGrabados = -1;

            Usuario UsuarioConNuevosDatos = CargarDatosNuevos(QCC, QCNU, QCE);

            nGrabados = objNegUsuario.abmUsuarios("Modificar", UsuarioConNuevosDatos); //invoco a la capa de negocio
            if (nGrabados == -1)
            {
                MessageBox.Show("No pudieron actualizar los datos");

            }
            else
            {
                MessageBox.Show("Datos actualizados");
                panelUpdate.Hide();
            }
               
        }

        private void btBorrarCuenta_Click(object sender, EventArgs e)
        {
            QuiereBorrar = true;
            VerificacionIdentidadForm VIF = new VerificacionIdentidadForm("VerificacionBorrar");
            VIF.EventoCerrar += VIFForm_Cerrado;
            VIF.ShowDialog();
            
            
        }

        // Se usan para verificar cual dato quiere cambiar el usuario
        #region Verificadores de Cambio
        private void tbxUpdateEmail_TextChanged(object sender, EventArgs e)
        {
            if (tbxUpdateEmail.Focused)
            {
                QCE = true;
            }
        }

        private void tbxUpdateUsername_TextChanged(object sender, EventArgs e)
        {
            if (tbxUpdateUsername.Focused)
            {
                QCNU = true;
            }
        }

        private void tbxUpdateContrasena_TextChanged(object sender, EventArgs e)
        {
            if (tbxUpdateContrasena.Focused)
            {
                QCC = true;
            }
        }
        #endregion

        bool QuiereBorrar;
        private void btAceptarCambios_Click(object sender, EventArgs e)
        {
            ModificarDatosUsuario(QCC, QCNU, QCE);
        }

        private void btCambiarDatos_Click(object sender, EventArgs e)
        {
            QCC = false;
            QCNU = false;
            QCE = false;
            tbxUpdateEmail.Text = UsuarioLogueado.Email;
            tbxUpdateUsername.Text = UsuarioLogueado.Nombre;
            VerificacionIdentidadForm VIF = new VerificacionIdentidadForm("Contrasena", UsuarioLogueado.Contrasena);
            VIF.EventoCerrar += VIFForm_Cerrado;
            VIF.ShowDialog();
        }

        public void VIFForm_Cerrado(object sender, EventArgs e)
        {
            VerificacionIdentidadForm VIF = sender as VerificacionIdentidadForm;
            //Recuperar el valor de propiedades definidas en Form2
            bool Verificado = VIF.VerificacionExitosa;
            Usuario usuario = objNegUsuario.BuscarUsuarioById(UsuarioLogueado.Id);
            if (Verificado)
            {
                panelUpdate.Show();
            }
            else if(Verificado && QuiereBorrar)
            {
                BorrarUsuario();
            }

        }

        private void btCancelarCambioDatos_Click(object sender, EventArgs e)
        {
            panelUpdate.Hide();
            QCE = false;
            QCNU = false;
            QCC = false;
        }

        private void btVolverDeUserOptions_Click(object sender, EventArgs e)
        {
            panelUpdate.Hide();
            QCE = false;
            QCNU = false;
            QCC = false;
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabSelect"];
        }

        private void btCerrarSesion_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabInicio"];
            UsuarioLogueado = null;
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
        private void tabUsuario_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Propiedades estéticas 
        private void btCrearPersonaje_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabCreacion"];
        }

        private void panelPersonajes_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabCreacion"];
        }

        private void btCambiarDatos_MouseHover(object sender, EventArgs e)
        {
            btCambiarDatos.BackColor = Color.DimGray;
        }

        private void btBorrarCuenta_MouseHover(object sender, EventArgs e)
        {
            btBorrarCuenta.BackColor = Color.DimGray;
            btBorrarCuenta.ForeColor = Color.Firebrick;

        }

        private void btCambiarDatos_MouseLeave(object sender, EventArgs e)
        {
            btCambiarDatos.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btBorrarCuenta_MouseLeave(object sender, EventArgs e)
        {
            btBorrarCuenta.BackColor = System.Drawing.SystemColors.Control;
            btBorrarCuenta.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            TabsDiseño.SelectedTab = TabsDiseño.TabPages["tabUsuario"];
        }





        #endregion

        

        private Personaje CargarDatosPJ()
        {
            Personaje pj = new Personaje();
            pj.IdUsuario = UsuarioLogueado.Id;
            pj.Nombre = tbxNombrePJ.Text;
            pj.Clase = cbxClasePJ.Text;
            pj.Nivel = int.Parse(lblCreacionNivel.Text);
            pj.Salud = int.Parse(lblCreacionSalud.Text);
            pj.Energia = int.Parse(lblCreacionEnergia.Text);
            pj.Ataque = int.Parse(lblCreacionAtaque.Text);
            pj.Defensa = int.Parse(lblCreacionDefensa.Text);
            pj.Evasion = int.Parse(lblCreacionEvasion.Text);


            lblCreacionArmadura.Text
            lblCreacionGuantes.Text
            lblCreacionPantalones.
            lblCreacionArma.Text
            lblCreacionEscudo.Text

        }

        private void btCrearPJ_Click(object sender, EventArgs e)
        {

        }

        private void cbxClasePJ_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxClasePJ.Text == "Mago")
            {
                lblCreacionNivel.Text = "1";
                lblCreacionCasco.Text = "Sombrero de Estrellas";
                lblCreacionArmadura.Text = "Túnica del Archimago";
                lblCreacionGuantes.Text = "Guantes de Cristal Arcano";
                lblCreacionPantalones.Text = "Calzas de la Nebulosa";
                lblCreacionArma.Text = "Báculo de Llamas Eternas";
                lblCreacionEscudo.Text = "Orbe del Vidente";

                lblCreacionSalud.Text = "50";
                lblCreacionEnergia.Text = "150";
                lblCreacionAtaque.Text = "20";
                lblCreacionDefensa.Text = "10";
                lblCreacionEvasion.Text = "15";
            }
            if (cbxClasePJ.Text == "Guerrero")
            {
                lblCreacionNivel.Text = "1";
                lblCreacionCasco.Text = "Yelmo del Inquebrantable";
                lblCreacionArmadura.Text = "Coraza del Centurión";
                lblCreacionGuantes.Text = "Guanteletes de Hierro Sangriento";
                lblCreacionPantalones.Text = "Grebas de la Fortaleza";
                lblCreacionArma.Text = "Espada de la Tempestad";
                lblCreacionEscudo.Text = "Escudo del Guardián";

                lblCreacionSalud.Text = "120";
                lblCreacionEnergia.Text = "50";
                lblCreacionAtaque.Text = "30";
                lblCreacionDefensa.Text = "40";
                lblCreacionEvasion.Text = "5";
            }
            if (cbxClasePJ.Text == "Ladrón")
            {
                lblCreacionNivel.Text = "1";
                lblCreacionCasco.Text = "Capucha del Sombrío";
                lblCreacionArmadura.Text = "Chaqueta de Sombras";
                lblCreacionGuantes.Text = "Guantes del Ratero";
                lblCreacionPantalones.Text = "Calzas del Acechador";
                lblCreacionArma.Text = "Daga del Alba Silenciosa";
                lblCreacionEscudo.Text = "Capa del Escapista";

                lblCreacionSalud.Text = "80";
                lblCreacionEnergia.Text = "100";
                lblCreacionAtaque.Text = "25";
                lblCreacionDefensa.Text = "15";
                lblCreacionEvasion.Text = "30";
            }
            if (cbxClasePJ.Text == "Clérigo")
            {
                lblCreacionNivel.Text = "1";
                lblCreacionCasco.Text = "Corona del Celestial";
                lblCreacionArmadura.Text = "Manto de la Devoción";
                lblCreacionGuantes.Text = "Manoplas del Sanador";
                lblCreacionPantalones.Text = "Sandalias del Protector";
                lblCreacionArma.Text = "Maza de la Penitencia";
                lblCreacionEscudo.Text = "Escudo del Redentor";

                lblCreacionSalud.Text = "70";
                lblCreacionEnergia.Text = "90";
                lblCreacionAtaque.Text = "18";
                lblCreacionDefensa.Text = "20";
                lblCreacionEvasion.Text = "10";
            }
            if (cbxClasePJ.Text == "Caballero")
            {
                lblCreacionNivel.Text = "1";
                lblCreacionCasco.Text = "Casco del Paladín Justiciero";
                lblCreacionArmadura.Text = "Armadura del Cruzado";
                lblCreacionGuantes.Text = "Guantes de Acero Bendito";
                lblCreacionPantalones.Text = "Botas del Centinela";
                lblCreacionArma.Text = "Espada de la Luz Sagrada";
                lblCreacionEscudo.Text = "Escudo del León Dorado";

                lblCreacionSalud.Text = "120";
                lblCreacionEnergia.Text = "40";
                lblCreacionAtaque.Text = "30";
                lblCreacionDefensa.Text = "50";
                lblCreacionEvasion.Text = "10";
            }
            if (cbxClasePJ.Text == "")
            {
                lblCreacionNivel.Text = "0";
                lblCreacionCasco.Text = "-";
                lblCreacionArmadura.Text = "-";
                lblCreacionGuantes.Text = "-";
                lblCreacionPantalones.Text = "-";
                lblCreacionArma.Text = "-";
                lblCreacionEscudo.Text = "-";

                lblCreacionSalud.Text = "0";
                lblCreacionEnergia.Text = "0";
                lblCreacionAtaque.Text = "0";
                lblCreacionDefensa.Text = "0";
                lblCreacionEvasion.Text = "0";
            }

        }
    }

}

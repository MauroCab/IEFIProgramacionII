using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentación
{
    public partial class VerificacionIdentidadForm : Form
    {
        public VerificacionIdentidadForm(string tipoVerificacion)
        {
            InitializeComponent();
            lblError.Hide();
            TipoVerificacion = tipoVerificacion;

            if (TipoVerificacion == "VerificacionBorrar")
            {
                lblInstruccion.Text = "Ingrese su contraseña para confirmar";
            }
            if (TipoVerificacion == "Email")
            {
                lblInstruccion.Text = "Ingrese su Email";
            }
            
            
        }

        public VerificacionIdentidadForm(string tipoVerificacion, string contrasenaUsuario)
        {

            InitializeComponent();
            lblError.Hide();
            TipoVerificacion = tipoVerificacion;
            lblInstruccion.Text = "Ingrese su contraseña";
            lblError.Text = "Contraseña incorrecta";
            ContrasenaUsuario = contrasenaUsuario;
        }

        #region Propiedades
        // Contraseña de aplicación para Gmail: xeri izcq qdda epkb

        public NegUsuarios objNegUsuario = new NegUsuarios();

        public string TipoVerificacion { get; set; }

        public string ContrasenaUsuario { get; set; }
        public string NuevaContrasena { get; set; }

        public bool VerificacionExitosa { get; set; } = false;

        public string UserEmail { get; set; } = "";
        #endregion

        private void btAceptarInput_Click(object sender, EventArgs e)
        {
            if (TipoVerificacion == "Email")
            {
                if (!objNegUsuario.EmailExiste(tbxInput.Text))
                {
                    MessageBox.Show("El Email ingresado no pertenece a un usuario registrado");
                }
                else
                {
                    UserEmail = tbxInput.Text;
                    EnviarCorreo(tbxInput.Text);
                }
            }

            if (TipoVerificacion == "Contrasena" || TipoVerificacion == "VerificacionBorrar")
            {
                if (tbxInput.Text != ContrasenaUsuario)
                {
                    lblError.Show();
                }
                else
                {
                    VerificacionExitosa = true;
                    this.CerrarForm();
                }
            }

            
        }

        private void EnviarCorreo(string destinatario)
        {
            string ContrasenaProvisional = GenerarContrasena()
                                        .Replace("&", "&amp;")
                                        .Replace("<", "&lt;")
                                        .Replace(">", "&gt;");
            try
            {
                // Crear el mensaje
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Equipo de RPG Character Manager", "rpgcharactermanagerteam@gmail.com"));
                email.To.Add(new MailboxAddress("", destinatario));
                email.Subject = "Recuperación de Contraseña";

                // Cuerpo del correo
                email.Body = new TextPart("html")
                {
                    Text = $@"
                            <html>
                                <body>
                                    <p>Hola</p>
                                    <p>Su contraseña provisional es: <strong>{ContrasenaProvisional}</strong></p>
                                    <p>Por favor, cámbiela después de iniciar sesión en su cuenta.</p>
                                    <p>Atentamente,<br>Equipo de RPG Character Manager</p>
                                </body>
                            </html>"

                };

                // Configuración y envío
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtpClient.Authenticate("rpgcharactermanagerteam@gmail.com", "xeri izcq qdda epkb");
                    smtpClient.Send(email);
                    smtpClient.Disconnect(true);
                }

                MessageBox.Show("Recuperacíon enviada al Email.");

                NuevaContrasena = ContrasenaProvisional;
                UserEmail = destinatario;
                this.CerrarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar el correo: {ex.Message}");
            }
        }

        private string GenerarContrasena()
        {
            const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!¡¿@#$%^&*()_-+=<>?";

            StringBuilder contrasena = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 12; i++)
            {
                int indice = random.Next(Chars.Length); 
                contrasena.Append(Chars[indice]);
            }

            
            return contrasena.ToString();

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento de cerrar con otro nombre (usado para que al cerrar de forma normal con
        //el X del form o el boton cancelar no ocurran ciertas validaciones, es decir para
        //que no salga un text box avisando de error)
        #region Cierre Propio
        public delegate void DelegadoCerrar(object sender, EventArgs e);
        public event DelegadoCerrar EventoCerrar;
        protected virtual void AlCerrar()
        {
            EventoCerrar?.Invoke(this, EventArgs.Empty);
        }

        public void CerrarForm()
        {
            this.Close();
            AlCerrar(); // Disparar el evento
        }
        #endregion

        private void tbxInput_TextChanged(object sender, EventArgs e)
        {
            lblError.Hide();
        }
    }
}









using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_AdrianMorales.Formularios
{
    public partial class FrmUsuarioRecuperarContrasenia : Form
    {



        public Logica.Email MyEmail { get; set; }
        public Logica.Models.Usuario MyUser { get; set; }

        public FrmUsuarioRecuperarContrasenia()
        {
            InitializeComponent();
            MyEmail = new Logica.Email();
            MyUser = new Logica.Models.Usuario();
        }

        private void FrmUsuarioRecuperarContrasenia_Load(object sender, EventArgs e)
        {
            TxtCodigoEnviado.Enabled = false;
            TxtPass1.Enabled = false;
            TxtPass2.Enabled = false;
            BtnAceptar.Enabled = false;

            TxtCodigoEnviado.Clear();
            TxtPass1.Clear();
            TxtPass2.Clear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void BtnEnviarCodigo_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(TxtUsuario.Text.Trim()))
            {
                ////// PROCEDIMIENTOS DEL EXAMEN /////////
                Logica.Bitacora bitacora = new Logica.Bitacora();

                bitacora.GuardarAccionEnBitacora(string.Format("Se ha solicitado recuperación de contraseña para el usuario: {0}",
                            TxtUsuario.Text.Trim()));

                ////// PROCEDIMIENTOS DEL EXAMEN /////////
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;


                if (!string.IsNullOrEmpty(TxtUsuario.Text.Trim()) &&
                Commons.ObjetosGlobales.ValidarEmail(TxtUsuario.Text.Trim()))
                {
                    MyUser.Email = TxtUsuario.Text.Trim();

                    if (MyUser.ConsultarPorEmail())
                    {
                        // Si el correo existe para un usuario activo. se procede a enviar el correo con un código de verificación
                        // que el usuario deberá digitar para comprobar que sea él.
                        // Este código se debería generar aleatoriamente
                        //TODO: ??

                        string CodigoVerificacion = "ABC123";

                        if (MyUser.EnviarCodigoRecuperacion(CodigoVerificacion))
                        {
                            // Se procede a enviar el correo al usuario con el código

                            MyEmail.Asunto = "Su código de recuperación de Tickets Progra 5 2021-3";

                            MyEmail.CorreoDestino = MyUser.Email;

                            string Mensaje = string.Format("Su código de recuperación de contraseña es: {0}", CodigoVerificacion);

                            MyEmail.Mensaje = Mensaje;

                            if (MyEmail.EnviarCorreo_Net_Mail_SmtpClient())
                            {
                                MessageBox.Show("Correo enviado correctamente", "Éxito", MessageBoxButtons.OK);

                                TxtPass1.Enabled = true;
                                TxtPass2.Enabled = true;
                                BtnAceptar.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("El correo no se pudo enviar!", "Error", MessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El correo no existe o el usuario está desactivado", "Error de validación", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                this.Cursor = Cursors.Default;
            
            }            
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //1. Se debe verificar que el código digitado sea el mismo que estça almacenado en la tabla Usuario
            //2. Las contraseñas deben ser las mismas.
            //3. Se procede con el cambio de contraseña

           

            if (!string.IsNullOrEmpty(TxtCodigoEnviado.Text.Trim()) && ValidarContrasenias())
            {
                // El dato del email ya se había asignado
                MyUser.CodigoRecuperacion = TxtCodigoEnviado.Text.Trim();
                MyUser.Contrasennia = TxtPass1.Text.Trim();

                if (MyUser.ComprobarCodigoRecuperacion())
                {
                    // Se tiene permiso de modificar la contraseña

                    if (MyUser.CambiarPassword())
                    {
                        MessageBox.Show("La contraseña se ha actualizado correctamente","Éxito", MessageBoxButtons.OK);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No se ha cambiado la contraseña", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("El código de verificación digitado no es correcto", "Error", MessageBoxButtons.OK);
                }
            }
        }


        private bool ValidarContrasenias()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtPass1.Text.Trim()) && 
                !string.IsNullOrEmpty(TxtPass2.Text.Trim()) && 
                TxtPass1.Text.Trim() == TxtPass2.Text.Trim())
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtPass1.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la nueva contraseña","Error de Validación", MessageBoxButtons.OK);
                    TxtPass1.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtPass2.Text.Trim()))
                {
                    MessageBox.Show("Debe verificar la contraseña", "Error de Validación", MessageBoxButtons.OK);
                    TxtPass2.Focus();
                    return false;
                }

                if (!string.IsNullOrEmpty(TxtPass1.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPass2.Text.Trim()) &&
                TxtPass1.Text.Trim() != TxtPass2.Text.Trim())
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error de Validación", MessageBoxButtons.OK);
                    TxtPass2.Focus();
                    return false;
                }
            }

            return R;
        }
    }
}

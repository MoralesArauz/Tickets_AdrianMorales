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
    public partial class FrmLogin : Form
    {
        // Control del evento de combinación de teclas
        private int secuencia = 0;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Salimos de la aplicación
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //TODO: Hay que validar que el usuario y la contraseña sean correctos
            //antes de mostrar el formulario principal

            if (ValidarDatos())
            {

                Logica.Models.Usuario MiUsuarioValidado = new Logica.Models.Usuario();

                MiUsuarioValidado = MiUsuarioValidado.ValidarIngreso(TxtEmail.Text.Trim(), TxtPassword.Text.Trim());

                if (MiUsuarioValidado != null && MiUsuarioValidado.IDUsuario > 0)
                {
                    Commons.ObjetosGlobales.MiUsuarioDeSistema = MiUsuarioValidado;
                    // Muestro el objeto global del FrmMain
                    Commons.ObjetosGlobales.MiFormPrincipal.Show();
                    // Oculto (no destruyo) el formulario de login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de Validación", MessageBoxButtons.OK);
                }

                
            }

            
        }

        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre de usuario","Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    return false;
                }
                if (!Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("El correo no tiene el formato correcto", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    TxtEmail.SelectAll();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contraseña", "Error de Validación", MessageBoxButtons.OK);
                    TxtPassword.Focus();
                    return false;
                }
            }

            return R;
        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.MiUsuarioDeSistema.IDUsuario = 1;
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Email = "morales.arauz@gmail.com";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre = "Usuario de Pruebas";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.MiRol.IDUsurioRol = 1;
            //muestro el objeto global del FrmMain
            Commons.ObjetosGlobales.MiFormPrincipal.Show();
            //oculto (no destruyo) el frm de Login
            this.Hide();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift & e.KeyCode == Keys.Escape)
            {
                BtnIngresoDirecto.Visible = true;
            }            
        }

        private void LblRecuperarContrasenia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Commons.ObjetosGlobales.FormularioRecuperarContrasenia.TxtUsuario.Text = this.TxtEmail.Text.Trim();

            Commons.ObjetosGlobales.FormularioRecuperarContrasenia.Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //LblNombre.Focus();
            //this.ActiveControl = LblNombre;
        }

        // Secuencia para mostrar el boton oculto
        // ˄˄ ˅˅ <> <> a b
        // Si no se oprime la tecla que sigue en la secuencia no se valida ni se reinicia.
        // Se utiliza un label para ir viendo las teclas oprimidas de la secuencia
        private void TxtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (secuencia == 0)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    else if (secuencia == 1)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;
                case Keys.Down:
                    if (secuencia == 2)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    else if (secuencia == 3)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;
                case Keys.Left:
                    if (secuencia == 4)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    else if (secuencia == 6)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;
                case Keys.Right:
                    if (secuencia == 5)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    else if (secuencia == 7)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;
                case Keys.A:
                    if (secuencia == 8)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;
                case Keys.B:
                    if (secuencia == 9)
                    {
                        secuencia++;
                        LblSecuencia.Text += e.KeyCode.ToString();
                    }
                    break;

            }

            if (secuencia == 10)
            {
                //MessageBox.Show("Ingresando secuencia", ":)", MessageBoxButtons.OK);
                BtnIngresoDirecto.Visible = true;
                secuencia = 0;
            }
        }
    }
}

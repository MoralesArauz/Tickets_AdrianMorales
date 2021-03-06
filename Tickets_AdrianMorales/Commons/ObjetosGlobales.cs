using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets_AdrianMorales.Commons
{
    public static class ObjetosGlobales
    {
        // Formularios de uso recurrente en el sistema
        // Si el formulario debería verse solo una vez por sesión
        // lo más conveniente es definirlo de forma estática y no dinámica.

        public static Form MiFormPrincipal = new Formularios.FrmMain();

        public static Formularios.FrmUsuarioGestion FormularioGestionDeUsuarios = new Formularios.FrmUsuarioGestion();
        
        // Se definen los objetos (basados en clases) que deben ser accesibles desde cualquier lugar de la aplicación
        public static Logica.Models.Usuario MiUsuarioDeSistema = new Logica.Models.Usuario();

        public static Formularios.FrmUsuarioRecuperarContrasenia FormularioRecuperarContrasenia = new Formularios.FrmUsuarioRecuperarContrasenia();

        public static Formularios.FrmTicketCrear FormCrearTicket = new Formularios.FrmTicketCrear();

        public static Formularios.FrmAtencionDeTickets FormAtencion = new Formularios.FrmAtencionDeTickets(); 

        
        const string EmailRegex =
       @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
       + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
       + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
       + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        /// <summary>
        /// Tarea 1
        /// </summary>
        // Expresiones regulares para validar la contraseña
        static Regex tieneNumeros = new Regex(@"[0-9]+");
        static Regex extraeNumeros = new Regex(@"\d+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static Regex tieneMayusculas = new Regex(@"[A-Z]+");
        static Regex limiteCaracteres = new Regex(@".{8,15}");
        static Regex tieneMinusculas = new Regex(@"[a-z]+");
        static Regex tieneSimbolos = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        /// <summary>
        /// Tarea 1
        /// </summary>
        public static bool ValidarEmail(string email)
        {
            if (email != null)
            {
                return Regex.IsMatch(email, EmailRegex);
            }
            else
            { return false; }

        }

        //Verifica si la contraseña tiene números pares
        public static bool ValidarNumerosPares(string contrasenia)
        {
            bool R = false;

            if (!tieneNumeros.IsMatch(contrasenia))
            {
                return true;
            }

            MatchCollection collection = extraeNumeros.Matches(contrasenia);//en el texto que vamos a buscar
            foreach (Match m in collection)
            {
                //por cada nro obtenido con la expresion regular,comparamos si es par o no
                if (Int32.Parse(m.Value) % 2 == 0)
                    // Encontró un número par
                    return true;
            }

            return R;
        }


        /// <summary>
        /// Tarea 1
        /// </summary>
        /*
            Mínimo 8 caracteres. 
            Debe tener mayúsculas. 
            Debe tener minúsculas. 
            Debe tener caracteres especiales como : !"·$%&/()=
            Debe tener números impares. 
         */
        public static bool ValidarPassword(string contrasennia)
        {
            
            if (string.IsNullOrWhiteSpace(contrasennia))
            {
                throw new Exception("Contraseña vacía");
            }

          
            if (!tieneMinusculas.IsMatch(contrasennia))
            {
                MessageBox.Show("La contraseña debe tener al menos una letra minúsculas", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (!tieneMayusculas.IsMatch(contrasennia))
            {
                MessageBox.Show("La contraseña debe tener letras mayúsculas", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (!limiteCaracteres.IsMatch(contrasennia))
            {
                MessageBox.Show("La contraseña debe tener entre 8 y 12 caracteres", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (ValidarNumerosPares(contrasennia))
            {
                MessageBox.Show("La contraseña debe tener solo números impares", "Error", MessageBoxButtons.OK);
                return false;
            }

            else if (!tieneSimbolos.IsMatch(contrasennia))
            {
                MessageBox.Show("La contraseña debe tener símbolos", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Tarea 1
        /// </summary>



        private static char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

        public static bool CaracteresTexto(System.Windows.Forms.KeyPressEventArgs c, bool Mayusculas = false, bool Minisculas = false)
        {
            bool ret = false;

            if (Mayusculas)
            { c.KeyChar = char.ToUpper(c.KeyChar); }

            if (Minisculas)
            { c.KeyChar = char.ToLower(c.KeyChar); }

            if (!(char.IsLetterOrDigit(c.KeyChar)) & !(char.IsPunctuation(c.KeyChar)) & !(c.KeyChar == Convert.ToChar(Keys.Back)) & !(c.KeyChar == Convert.ToChar(Keys.Space)) & !(c.KeyChar == Convert.ToChar(Keys.Enter)))
                ret = true;
            else
                ret = false;
            return
            ret;

        }

        public static bool CaracteresNumeros(System.Windows.Forms.KeyPressEventArgs c, bool SoloEnteros = true)
        {
            //En el caso que presione enter acepta el valor y devuelve True
            int Asc = (int)Keys.Enter;

            if (c.KeyChar == Asc)
            {
                return true;
            }
            if (SoloEnteros == false)
            {
                if (c.KeyChar.ToString() == (".") | c.KeyChar.ToString() == (","))
                {
                    c.KeyChar = DecimalSeparator;
                    return false;
                }
            }

            if (!(char.IsDigit(c.KeyChar)) & !(c.KeyChar == Convert.ToChar(Keys.Back)) & !(c.KeyChar == Convert.ToChar(Keys.Enter)))
            { return true; }
            else
            { return false; }

        }

        public static string DateFormat(DateTime pDate, bool ISO_Format = false)
        {
            string s = string.Empty;

            try
            {
                if (ISO_Format)
                {
                    string yyyy;
                    string mm;
                    string dd;
                    int i_mm = pDate.Month;
                    int i_dd = pDate.Day;

                    if (i_mm < 10)
                    {
                        mm = "0" + i_mm.ToString();
                    }
                    else
                    {
                        mm = i_mm.ToString();
                    }

                    if (i_dd < 10)
                    {
                        dd = "0" + i_dd.ToString();
                    }
                    else
                    {
                        dd = i_dd.ToString();
                    }

                    yyyy = pDate.Year.ToString();

                    s = yyyy + mm + dd;
                }
                else
                {
                    s = string.Format("{0:dd/MMMM/yyyy}", pDate.Date);
                }
            }
            catch (Exception e)
            {
                s = e.ToString();
            }

            return s;
        }


        public static string FormatoHora(DateTime pDate)
        {
            string h;

            h = pDate.ToLongTimeString();

            return h;
        }


        public static void GuardarEnBitacora(string accion, int IDUsuario)
        {
            ////// PROCEDIMIENTOS DEL EXAMEN /////////
            Logica.Bitacora bitacora = new Logica.Bitacora();
            // También podría ser el nombre del usuario
            bitacora.GuardarAccionEnBitacora(accion,IDUsuario);

            ////// PROCEDIMIENTOS DEL EXAMEN /////////
        }

    }
}

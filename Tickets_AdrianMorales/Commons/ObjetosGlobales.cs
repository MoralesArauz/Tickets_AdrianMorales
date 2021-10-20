using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}

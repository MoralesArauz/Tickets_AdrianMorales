using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class UsuarioTicket
    {
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string AnotacionDelUsuario { get; set; }

        public Usuario MiUsuario { get; set; }

        public UsuarioTicket()
        {
            MiUsuario = new Usuario();
        }

        public bool IniciarAtencionTicket(int iDUsuarioQueAtiende)
        {
            return false;
        }

        public bool EstablecerComentarioDeUsuario(int IDUsuario, string ComentarioUsuario)
        {
            return false;
        }

        public bool FinalizarAtencionTicket(int IDUsuario)
        {
            return false;
        }
    }
}

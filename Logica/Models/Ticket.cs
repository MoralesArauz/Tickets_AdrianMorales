using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Ticket
    {
        public int IDTicket { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string TicketTitulo { get; set; }
        public string TicketDescripcion { get; set; }
        public int CantidadTiempo { get; set; }
        public bool Pagado { get; set; }
        public bool Activo { get; set; }

        public Ticket()
        {
            CantidadTiempo = 0;
            Micategoria = new TicketCategoria();
            MiCliente = new Cliente();
            MiListaDeUsuarios = new List<UsuarioTicket>();
        }

        // Esta clase es la más complicada en composiciones


        public TicketCategoria Micategoria { get; set; }
        public Cliente MiCliente { get; set; }
        public List<UsuarioTicket> MiListaDeUsuarios { get; set; }

        // funciones
        public bool Agregar()
        {
            return false;
        }

        public bool Eliminar()
        {
            return false;
        }
        public bool IniciarTicket()
        {
            return false;
        }

        public bool FinalizarTicket()
        {
            return false;
        }

        public bool EstalecerPagado()
        {
            return false;
        }
    }
}

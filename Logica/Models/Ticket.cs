using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCliente",this.MiCliente.IDCliente));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.Micategoria.IDTicketCategoria));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Titulo", this.TicketTitulo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.TicketDescripcion));
            // Para que devuelva el ID del ticket recién agregado.
            Object i = MiCnn.DMLConRetornoEscalar("SPTicketAgregar");
            
            if (i != null)
            {
                // Hay que asignar al ID del Ticket el valor del ID creado en el SP
                // Ya que es fundamental para la visualización del reporte.

                this.IDTicket = Convert.ToInt32(i.ToString());
                 
                R = true;
            }

            return R;
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

        public ReportDocument Imprimir(ReportDocument reporte) 
        {
            ReportDocument R = reporte;

            Crystal OCrystal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDTicket", this.IDTicket));

            Datos = MiCnn.DMLSelect("SPTicketReporte");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                // Se le asigna al reporte que diseñamos los datos que provienen del SP
                OCrystal.Datos = Datos;

                R = OCrystal.GenerarReporte();
            }

            return R;
        }
    }
}

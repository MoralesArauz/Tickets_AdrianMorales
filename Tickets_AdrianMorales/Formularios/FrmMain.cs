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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void TmrHora_Tick(object sender, EventArgs e)
        {
            LblTextoHora.Text = DateTime.Now.ToLongDateString() +" "+ DateTime.Now.ToLongTimeString();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TmrHora.Enabled = true;
            LblUsuarioLogueado.Text = Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Analizar si queremos hacer un logout cuando cerramos el principal
            ////// PROCEDIMIENTOS DEL EXAMEN /////////
            Logica.Bitacora bitacora = new Logica.Bitacora();
            // También podría ser el nombre del usuario
            bitacora.GuardarAccionEnBitacora(string.Format("Cierre de sesión por parte del usuario: {0}", Commons.ObjetosGlobales.MiUsuarioDeSistema.Email),
                Commons.ObjetosGlobales.MiUsuarioDeSistema.IDUsuario);

            ////// PROCEDIMIENTOS DEL EXAMEN /////////
            Application.Exit();
        }

        private void gestiónDeUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Mostramos formulario global de gestión de usuarios
            // Esto es por el Dispose que sucede cuando cierro el formulario
            Commons.ObjetosGlobales.FormularioGestionDeUsuarios = new FrmUsuarioGestion();

            Commons.ObjetosGlobales.FormularioGestionDeUsuarios.Show();
        }

        private void gestiónDeClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void creaciónDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormCrearTicket = new FrmTicketCrear();
            Commons.ObjetosGlobales.FormCrearTicket.Show();
        }

        private void soluciónDeTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormAtencion = new FrmAtencionDeTickets();
            Commons.ObjetosGlobales.FormAtencion.Show();
        }
    }
}

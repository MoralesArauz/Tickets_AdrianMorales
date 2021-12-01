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
    public partial class FrmClienteBuscar : Form
    {

        // Definimos los atributos locales
        Logica.Models.Cliente MiCliente { get; set; }

        public DataTable DtLista { get; set; }

        public FrmClienteBuscar()
        {
            InitializeComponent();
            MiCliente = new Logica.Models.Cliente();
            DtLista = new DataTable();
        }

        private void LlenarListaClientes(string Filtro = "")
        {
            DtLista = new DataTable();
            DtLista = MiCliente.ListarActivos(Filtro);
            DgvLista.DataSource = DtLista;
        }

        private void FrmClienteBuscar_Load(object sender, EventArgs e)
        {
            LlenarListaClientes();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgvLista.Rows.Count > 0 && DgvLista.SelectedRows.Count == 1)
            {
                int IDCliente = Convert.ToInt32(DgvLista.SelectedRows[0].Cells["CIDCliente"].Value);
                string Cliente = Convert.ToString(DgvLista.SelectedRows[0].Cells["CNombre"].Value);
                // Una vez que he capturado la información necesaria de las columnas del DataGridView
                // puedo pasar estos al objeto local MiTicket
                Commons.ObjetosGlobales.FormCrearTicket.MiTicket.MiCliente.IDCliente = IDCliente;
                Commons.ObjetosGlobales.FormCrearTicket.MiTicket.MiCliente.Nombre = Cliente;

                // Esto cierra el form y retorna una respuesta al formulario que lo invocó
                this.DialogResult = DialogResult.OK;

            }
        }

       
    }
}

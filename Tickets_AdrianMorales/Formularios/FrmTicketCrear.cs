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
    public partial class FrmTicketCrear : Form
    {

        public Logica.Models.Ticket MiTicket { get; set; }


        public FrmTicketCrear()
        {
            InitializeComponent();
            MiTicket = new Logica.Models.Ticket();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtIDUsuario_DoubleClick(object sender, EventArgs e)
        {
            FrmClienteBuscar MiFormDeBusqueda = new FrmClienteBuscar();

            DialogResult respuesta = MiFormDeBusqueda.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                TxtIDUsuario.Text = MiTicket.MiCliente.IDCliente.ToString();
                LblClienteNombre.Text = MiTicket.MiCliente.Nombre;
            }
        }

        private void TxtIDUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarCategorias()
        {
            DataTable Datos = new DataTable();

            //SDUsuarioRolListar Paso 2

            Datos = MiTicket.Micategoria.Listar();
            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Descrip";

            // SDUsuarioRolListar Paso 2.5
            CboxCategoria.DataSource = Datos;

            CboxCategoria.SelectedIndex = -1;

        }

        private void FrmTicketCrear_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            TxtIDUsuario.Clear();
            LblClienteNombre.Text = "";
            CboxCategoria.SelectedIndex = -1;
            TxtTitulo.Clear();
            TxtDescripcion.Clear();

            MiTicket = new Logica.Models.Ticket();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                // Está todo listo para agregar el Ticket
                MiTicket.Micategoria.IDTicketCategoria = Convert.ToInt32(CboxCategoria.SelectedValue);
                // No es necesario, con el ID es más que suficiente
                MiTicket.Micategoria.TicketCategoriaDescripcion = Convert.ToString(CboxCategoria.SelectedText);
                // No es necesario agregar la fecha porque se define desde la base de datos
                MiTicket.TicketTitulo = TxtTitulo.Text.Trim();
                MiTicket.TicketDescripcion = TxtDescripcion.Text.Trim();

                if (MiTicket.Agregar())
                {
                    MessageBox.Show("Ticket agregado correctamente.", "Agregado", MessageBoxButtons.OK);
                    //TODO: Implementar un reporte de crystal para poderlo imprimir y que quede
                    //como atestado de creación del Ticket
                    LimpiarForm();
                }
            }
        }

        private bool Validar()
        {
            bool R = false;

            if (MiTicket.MiCliente.IDCliente > 0 &&
                CboxCategoria.SelectedIndex > -1 &&
                !string.IsNullOrEmpty(TxtTitulo.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (MiTicket.MiCliente.IDCliente == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente","Datos Insuficientes", MessageBoxButtons.OK);
                    return false;
                }

                if (CboxCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoría para el Ticket", "Datos Insuficientes", MessageBoxButtons.OK);
                    return false;
                }

                if (string.IsNullOrEmpty(TxtTitulo.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un título para el Ticket", "Datos Insuficientes", MessageBoxButtons.OK);
                    TxtTitulo.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una descripción para el Ticket", "Datos Insuficientes", MessageBoxButtons.OK);
                    TxtDescripcion.Focus();
                    return false;
                }
            }

            return R;
        }
    }
}

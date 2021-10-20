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
    public partial class FrmUsuarioGestion : Form
    {

        // Este objeto será el que se usa para asignar y obtener los valores que
        // se mostraran en el formulario (la parte gráfica)
        // debería contener toda la funcionalidad que se requiere para cumplir
        // los requerimientos Funcionales
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }



        public FrmUsuarioGestion()
        {
            InitializeComponent();

            // Se instancia el objeto local
            //SDUsuarioRolListar Paso 1 y 1.1
            //SDUsuarioAgregar Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            // Este código se desencadena al mostrar el Form grádicamente en pantalla
            // primero vamos a llenar la info de los tipos de roles que existen en BD
            CargarComboRoles();

        }

        private void CargarComboRoles()
        {
            DataTable DatosDeRoles = new DataTable();

            //SDUsuarioRolListar Paso 2
            
            DatosDeRoles = MiUsuarioLocal.MiRol.Listar();

            CbRol.ValueMember = "ID";
            CbRol.DisplayMember = "Descrip";

            // SDUsuarioRolListar Paso 2.5
            CbRol.DataSource = DatosDeRoles;

            CbRol.SelectedIndex = -1;

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            // Asignación de valores a atributos
            MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
            MiUsuarioLocal.Email = TxtEmail.Text.Trim();

            // Paso 1.3 y 1.3.6
            bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);
            // Paso 1.4 y 1.4.6
            bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();

            //1.5
            if (!OkCedula && !OkEmail)
            {
                // Si no existe la cedula y si no existe el email, entonces agregamos el Usuario

                //1.6
                bool OkAgregar = MiUsuarioLocal.Agregar();
            }
            
        }
    }
}

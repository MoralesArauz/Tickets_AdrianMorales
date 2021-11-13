﻿using System;
using System.Data;
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
        private DataTable ListarUsuarios { get; set; }
        private DataTable ListarUsuariosConFlitro { get; set; }
        public FrmUsuarioGestion()
        {
            InitializeComponent();

            // Se instancia el objeto local
            //SDUsuarioRolListar Paso 1 y 1.1
            //SDUsuarioAgregar Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();
            ListarUsuarios = new DataTable();
            ListarUsuariosConFlitro = new DataTable();
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            // Este código se desencadena al mostrar el Form grádicamente en pantalla
            // primero vamos a llenar la info de los tipos de roles que existen en BD
            CargarComboRoles();

            // Cargar la lista de Usuarios
            LlenarListaUsuarios();
            LimpiarFormulario();
        }

        private void LlenarListaUsuarios()
        {
            ListarUsuarios = MiUsuarioLocal.Listar();
            DgvListaUsusarios.DataSource = ListarUsuarios;

            DgvListaUsusarios.ClearSelection();
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

        // Esta funcion valida los datos requeridos según se diseñó el modelo
        // lógico y físico de base de datos
        // Debería avisar al Usuario que dato está haciendo falta.
        private bool ValidarDatosRequeridos()
        {
            bool R = false;
            string mensajeError = "";

            if (string.IsNullOrEmpty(MiUsuarioLocal.Nombre)){
                mensajeError += "El campo Nombre es obligatorio.\n";
            }
            if (string.IsNullOrEmpty(MiUsuarioLocal.Cedula))
            {
                mensajeError += "El campo Cédula es obligatorio.\n";
            }
            if (string.IsNullOrEmpty(MiUsuarioLocal.Email))
            {
                mensajeError += "El campo Email es obligatorio.\n";
            }
            if (string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia))
            {
                mensajeError += "El campo Contraseña es obligatorio.\n";
            }
            if (MiUsuarioLocal.MiRol.IDUsurioRol <=0)
            {
                mensajeError += "Debe escoger un Rol.\n";
            }
            if (string.IsNullOrEmpty(mensajeError))
            {
                // Si se cumplen los parámetros de validación se pasa el valor de R a true
                R = true;
            }
            else
            {
                // Trabajo en clase:
                //retroalimentar al usuario para indicar qué campo hace falta digitar
                MessageBox.Show(mensajeError, "Datos Insuficientes", MessageBoxButtons.OK);

            }

            return R;
        }

        private void LimpiarFormulario()
        {
            // Se procede a limpiar los datos de los controles del formulario
            TxtIDUsuario.Clear();
            TxtNombre.Clear();
            TxtTelefono.Clear();
            TxtContrasenia.Clear();
            TxtCedula.Clear();
            TxtEmail.Clear();
            CbRol.SelectedIndex = -1;

            // Al reinstanciar el objeto local se eliminan todos los datos de los atributos
            MiUsuarioLocal = new Logica.Models.Usuario();

            ActivarAgregar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            // La asignación de valores a atributos se realiza en tiempo real,
            // usaremos el evento para almacenar el dato del atributo al objeto local
            // Es importante que todos tengan datos antes de proceder
            /* if (ValidarDatosRequeridos())
             {
                 // Paso 1.3 y 1.3.6
                 bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);
                 // Paso 1.4 y 1.4.6
                 bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();

                 //1.5
                 if (!OkCedula && !OkEmail)
                 {
                     // Si no existe la cedula y si no existe el email, entonces agregamos el Usuario

                     //1.6
                     // Solicita si se quiere eliminar el usuario realmente
                     DialogResult Continuar = MessageBox.Show(string.Format("Está seguro que quiere Agregar al usuario {0}", MiUsuarioLocal.Nombre), "Eliminar Usuario", MessageBoxButtons.YesNo);

                     if (Continuar == DialogResult.Yes)
                     {
                         if (MiUsuarioLocal.Agregar())
                         {
                             MessageBox.Show("Usuario Agregado Correctamente!", "Éxito", MessageBoxButtons.OK);
                             //TODO: Se procede a limpiar el formulario y a recargar la lista de usuarios en el DataGrid
                             LimpiarFormulario();
                             LlenarListaUsuarios();
                         }
                         else
                         {
                             MessageBox.Show("Ha ocurrido un error y no se ha guardado el usuario", "Error", MessageBoxButtons.OK);
                         }
                     }
                 }

             }*/


            if (Commons.ObjetosGlobales.ValidarPassword(TxtContrasenia.Text))
            {
                MessageBox.Show("Contraseña válida", "Correcto", MessageBoxButtons.OK);
            }
            
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();   
        }

        private void TxtCedula_Leave(object sender, EventArgs e)
        {
            MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            
            MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()))
            {
                MiUsuarioLocal.Email = TxtEmail.Text.Trim();
            }
            else
            {
                MessageBox.Show("El formato del correo no es correcto", "Error de Validación", MessageBoxButtons.OK);
                TxtEmail.Focus();
                TxtEmail.SelectAll();
            }
            
        }

        private void TxtContrasenia_Leave(object sender, EventArgs e)
        {
            MiUsuarioLocal.Contrasennia = TxtContrasenia.Text.Trim(); 
        }

        private void CbRol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbRol.SelectedIndex>=0)
            {
                MiUsuarioLocal.MiRol.IDUsurioRol = Convert.ToInt32(CbRol.SelectedValue);
            }
            else
            {
                CbRol.SelectedIndex = 0;
            }
            
            
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Según el diagrama de casos de usu expandido, se debe consultar por el
            // ID antes de proceder con el proceso de actualización
            // Esto debería estar explicado en el diagrama de secuencia correspondiente
            if (ValidarDatosRequeridos())
            {
                // Si se cumplen los datos mínimos, se procede
                // Uso un objeto temporal para no tocar el usuario local y poder evaluar
                // (si tiene datos en los atributos) que el usuario existe aun en la BD
                Logica.Models.Usuario ObjUsuario = MiUsuarioLocal.consultarPorID(MiUsuarioLocal.IDUsuario);

                // Solicita si se quiere eliminar el usuario realmente
                DialogResult Continuar = MessageBox.Show(string.Format("Está seguro que quiere eliminar al usuario {0}",ObjUsuario.Nombre), "Eliminar Usuario", MessageBoxButtons.YesNo);

                if (Continuar == DialogResult.Yes)
                {
                    if (ObjUsuario.IDUsuario > 0)
                    {
                        // Si el ID(o cualquier atributo obligatorio) tiene datos, se puede
                        // asegurar que el usuario existe y se puede proceder con el update

                        if (MiUsuarioLocal.Editar())
                        {
                            // Se muestra mensaje de éxito y se actualiza la lista
                            MessageBox.Show("El usuario se ha actualizado correctamente", "Correcto", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            LlenarListaUsuarios();

                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se actualizó el usuario", "incorrecto", MessageBoxButtons.OK);

                        }
                    }
                }

                
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Según el diagrama de casos de usu expandido, se debe consultar por el
            // ID antes de proceder con el proceso de actualización
            // Esto debería estar explicado en el diagrama de secuencia correspondiente
            if (ValidarDatosRequeridos())
            {
                // Uso un objeto temporal para no tocar el usuario local y poder evaluar
                // (si tiene datos en los atributos) que el usuario existe aun en la BD
                Logica.Models.Usuario ObjUsuarioTemporal = MiUsuarioLocal.consultarPorID(MiUsuarioLocal.IDUsuario);
                
                // Solicita si se quiere eliminar el usuario realmente
                DialogResult Continuar = MessageBox.Show("Está seguro que quiere eliminar al usuario " + ObjUsuarioTemporal.Nombre, "Eliminar Usuario", MessageBoxButtons.YesNo);

                if (Continuar == DialogResult.Yes)
                {
                    // Si se cumplen los datos mínimos, se procede
                    if (ObjUsuarioTemporal.IDUsuario > 0)
                    {
                        // Si el ID(o cualquier atributo obligatorio) tiene datos, se puede
                        // asegurar que el usuario existe y se puede proceder con el delete

                        if (MiUsuarioLocal.Eliminar())
                        {
                            LimpiarFormulario();
                            LlenarListaUsuarios();
                            // Se muestra mensaje de éxito y se actualiza la lista
                            MessageBox.Show("El usuario" + ObjUsuarioTemporal.Nombre + " se ha eliminado correctamente", "Correcto", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se eliminó el usuario", "incorrecto", MessageBoxButtons.OK);

                        }
                    }
                }
                else if (Continuar == DialogResult.No)
                {
                    MessageBox.Show("No se ha eliminado el Usuario", "Eliminar Usuario", MessageBoxButtons.OK);
                }
            }
        }

        private void DgvListaUsusarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsusarios.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = DgvListaUsusarios.SelectedRows[0];

                int CodigoUsuario = Convert.ToInt32(MiFila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = MiUsuarioLocal.consultarPorID(CodigoUsuario);

                TxtIDUsuario.Text = MiUsuarioLocal.IDUsuario.ToString();
                TxtNombre.Text = MiUsuarioLocal.Nombre;
                TxtCedula.Text = MiUsuarioLocal.Cedula;
                TxtTelefono.Text = MiUsuarioLocal.Telefono;
                TxtEmail.Text = MiUsuarioLocal.Email;
                //TxtContrasenia.Text = MiUsuarioLocal.Contrasennia;
                CbRol.SelectedValue = MiUsuarioLocal.MiRol.IDUsurioRol;

                ActivarModificaryEliminar();
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, true);
        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e);
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, false, true);
        }

        private void ActivarAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void ActivarModificaryEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
        }
    }
}

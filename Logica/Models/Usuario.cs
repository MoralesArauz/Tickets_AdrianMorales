﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario : ICrudBase, IPersona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnnAdd = new Conexion();

            // Agregar los parámetros para el SP

            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
            // TODO: Encriptar contraseña
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@Contrasennia", this.Contrasennia));
            MiCnnAdd.ListadoDeParametros.Add(new SqlParameter("@IdRol", this.MiRol.IDUsurioRol));

            // 1.6.3 y 1.6.4
            int resultado = MiCnnAdd.DMLUpdateDeleteInsert("SPUsuarioAgregar");

            // 1.6.5
            if (resultado > 0)
            {
                R = true;
            }
            
            return R;
        }

        public bool Editar()
        {
            return false;
        }

        public bool Eliminar()
        {
            return false;
        }

        // Atributos propios de la clase
        public int IDUsuario { get; set; }
        public string CodigoRecuperacion { get; set; }
        public string Contrasennia { get; set; }

        // Composición del Rol del Usuario
        public UsuarioRol MiRol { get; set; }

        // Constructor
        public Usuario()
        {
            MiRol = new UsuarioRol();
        }

        //Funciones propias de la clase
        public bool Agregar(string cedula, string nombre, string telefono, string email, string contrasennia)
        {
            return false;
        }

       public Usuario consultarPorID(int ID)
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID));

            DataTable DatosUsuario = new DataTable();

            DatosUsuario = MiCnn.DMLSelect("SPUsuarioConsultarPorID");

            if (DatosUsuario != null && DatosUsuario.Rows.Count == 1)
            {
                DataRow Fila = DatosUsuario.Rows[0];

                R.IDUsuario = ID;
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Cedula = Convert.ToString(Fila["Cedula"]);
                R.Telefono = Convert.ToString(Fila["Telefono"]);
                R.Email = Convert.ToString(Fila["Email"]);
                R.Contrasennia = Convert.ToString(Fila["Contrasennia"]);
                R.MiRol.IDUsurioRol = Convert.ToInt32(Fila["IDUsuarioRol"]);
            }

            return R;
        }

       public bool ConsultarPorCedula(string cedula)
        {

            bool R = false;

            // Paso 1.3.1 y 1.3.2
            Conexion MiConexion = new Conexion();

            //En este caso y de forma didactica se decidió implementar un parámetro para la cédula
            //este valor debe agregarse como parámetro que debe llegar hasta el SP.
            MiConexion.ListadoDeParametros.Add(new SqlParameter("@Cedula",cedula));

            // Paso 1.3.3 y 1.3.4
            DataTable retorno = MiConexion.DMLSelect("SPUsuarioConsultarPorCedula");

            // Paso 1.3.5
            if (retorno != null && retorno.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;
            // Paso 1.4.1 y 1.4.2
            Conexion MiCnn = new Conexion();
            //agregar el parámetro que debe llegar con el valor del email a consultar
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
            // 1.4.3 y 1.4.4
            DataTable resultado = MiCnn.DMLSelect("SPUsuarioConsultarPorEmail");


            // 1.4.5
            if (resultado != null && resultado.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public DataTable Listar(bool verActivos = true)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.DMLSelect("SPUsuariosListar");

            return R;
        }

        public bool EnviarCodigoRecuperacion()
        {
            return false;
        }

        public bool CambiarPassword(int id, string nuevaContrasennia)
        {
            return false;
        }
    }
}

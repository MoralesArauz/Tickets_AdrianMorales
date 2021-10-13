using System;
using System.Collections.Generic;
using System.Data;
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
            return false;
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

       private Usuario consultarPorID(int ID)
        {
            return null;
        }

       private bool ConsultarPorCedula(string cedula)
        {
            return false;
        }

        private bool ConsultarPorEmail()
        {
            return false;
        }

        public DataTable Listar(bool verActivos = true)
        {
            return null;
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

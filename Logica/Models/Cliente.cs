using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente : ICrudBase, IPersona
    {

        // Estos atributos vienen de IPersona
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

   
        // Estas funciones vienen de ICrudBase
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
        public int IDCliente { get; set; }
        public string Direccion { get; set; }
        public bool EnviarPromos { get; set; }

        // Se analiza si hay atributos compuestos y se agregan
        public ClienteCategoria MiCategoria { get; set; }

        // Cuando tenemos atributos compuestos es necesario instanciarlos en el constructor
        // de la clase
        public Cliente()
        {
            MiCategoria = new ClienteCategoria();
        }

        // Funciones propias de la clase

        bool ConsultarPorID(int ID)
        {
            return false;
        }

        bool ConsultarPorCedula(string Cedula)
        {
            return false;
        }

        public DataTable ListarActivos(string Filtro = "")
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            R = MiCnn.DMLSelect("SPClienteBuscar");

            return R;
        }

        public DataTable ListarInactivos()
        {
            return null;
        }
    }
}

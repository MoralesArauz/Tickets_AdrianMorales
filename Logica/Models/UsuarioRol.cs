using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class UsuarioRol : ICrudBase
    {

        public int IDUsurioRol { get; set; }

        public string UsuarioRolDescripcion { get; set; }
        // Estas funciones deben cumplir el contrato escrito en la interface ICrudBase
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

        // Las siguientes funciones son las específicas que no están en ICrudBase
        // Osea no son comunes para más de una clase.

        bool ConsultarPorID()
        {
            return false;
        }
        bool ConsultarPorNombre()
        {
            return false;
        }

        DataTable Listar()
        {
            // SEQ: SDUsurioRolListar
            DataTable R = new DataTable();

            return R;
        }
    }
}

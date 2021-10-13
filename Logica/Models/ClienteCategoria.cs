using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class ClienteCategoria
    {
        //Hay varias formas de usar los atributos de una clase, esta es
        //auto implementación
        public int IDClienteCategoria { get; set; }

        private string clienteCategoriaDescripcion;

        public string ClienteCategoriaDescripcion
        {
            get { return clienteCategoriaDescripcion; }
            set { clienteCategoriaDescripcion = value; }
        }

        // luego de escribir los atributos, seguimos con las funciones y métodos

        public DataTable Listar()
        {
            DataTable R = new DataTable();
            // acá va la funcionalidad para obtener la data desde la BD por medio 
            //de un SP


            return R;
        }
    }
}

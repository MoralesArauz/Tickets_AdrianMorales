﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class TicketCategoria
    {
        // atributos
        public int IDTicketCategoria { get; set; }
        public string TicketCategoriaDescripcion { get; set; }

        // Comportamientos

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //TODO:

            return R;
        }
    }
}

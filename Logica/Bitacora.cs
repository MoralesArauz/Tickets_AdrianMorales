using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Bitacora
    {
        public string Accion { get; set; }
        public int IDUsuario { get; set; }

        
        public bool GuardarAccionEnBitacora(string accion, int IDUsuario = 0)
        {
            bool R = false;
            Accion = accion;
            this.IDUsuario = IDUsuario;


            if (!string.IsNullOrEmpty(Accion))
            {
                Models.Conexion MiCnn = new Models.Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDUsuario", this.IDUsuario));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Accion", Accion));

                int resultado = MiCnn.DMLUpdateDeleteInsert("SPBitacoraAgregarRegistro");

                if (resultado > 0)
                {
                    R = true;
                }
            }

            return R;
        }
    }
}

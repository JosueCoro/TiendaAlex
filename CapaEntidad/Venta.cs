using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE comercio.venta 
    (
     id_venta INTEGER NOT NULL IDENTITY(1,1), 
     fecha DATE NOT NULL , 
     monto_total DECIMAL (30,3) NOT NULL , 
     cliente_id_cliente INTEGER NOT NULL , 
     direccion_id_direccion INTEGER NOT NULL 
    )
GO*/
    public class Venta
    {
        public int id_venta { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto_total { get; set; }
        public int cliente_id_cliente { get; set; }
        public int direccion_id_direccion { get; set; }

        // Constructor
        public Venta()
        {
            fecha = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE administracion.permisos 
    (
     id_permisos INTEGER NOT NULL , 
     accion VARCHAR (150) NOT NULL , 
     estado BIT NOT NULL 
    )
GO
*/
    public class Permisos
    {
        public int id_permisos { get; set; }
        public string accion { get; set; }
        public bool estado { get; set; }
    }
}

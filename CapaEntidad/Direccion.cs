using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE comercio.direccion 
    (
     id_direccion INTEGER NOT NULL , 
     departamento VARCHAR (150) NOT NULL , 
     ciudad VARCHAR (150) NOT NULL 
    )
GO*/
    public class Direccion
    {
        public int id_direccion { get; set; }
        public string departamento { get; set; }
        public string ciudad { get; set; }
    }
}

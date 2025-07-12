using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE comercio.cliente 
    (
     id_cliente INTEGER NOT NULL , 
     nombre VARCHAR (80) NOT NULL , 
     apellido1 VARCHAR (80) NOT NULL , 
     apellido2 VARCHAR (80) , 
     correo VARCHAR NOT NULL , 
     contraseña VARCHAR (150) NOT NULL , 
     telefono VARCHAR (10) NOT NULL , 
     estado BIT NOT NULL , 
     fecha_registro DATETIME NOT NULL 
    )
GO*/
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}

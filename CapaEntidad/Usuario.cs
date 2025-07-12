using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE administracion.usuario 
    (
     id_usuario INTEGER NOT NULL , 
     nombre VARCHAR (150) NOT NULL , 
     apellido VARCHAR (150) NOT NULL , 
     correo VARCHAR (150) NOT NULL , 
     contraseña VARCHAR (150) NOT NULL , 
     estado BIT NOT NULL , 
     rol_id_rol INTEGER NOT NULL 
    )
GO*/
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public bool estado { get; set; }
        public int rol_id_rol { get; set; }
    }
}

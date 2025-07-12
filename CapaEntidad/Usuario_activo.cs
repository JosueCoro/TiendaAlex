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
    public class Usuario_activo
    {
        public int id_usuario_activo { get; set; }
        public string nombre_activo { get; set; }
        public string apellido_activo { get; set; }
        public string correo_activo { get; set; }
        public string contraseña_activo { get; set; }
        public bool estado_activo { get; set; }
        public int rol_id_rol_activo { get; set; }
    }
}

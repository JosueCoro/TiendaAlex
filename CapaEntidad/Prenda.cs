using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE comercio.prenda 
    (
     id_prenda INTEGER NOT NULL IDENTITY(1,1), 
     nombre VARCHAR (150) NOT NULL , 
     descripcion VARCHAR (150) NOT NULL , 
     estado BIT NOT NULL , 
     precio DECIMAL (30,3) NOT NULL , 
     ruta_imagen VARCHAR (150) NOT NULL , 
     nombre_imagen VARCHAR (150) NOT NULL , 
     usuario_id_usuario INTEGER NOT NULL , 
     caregoria_id_categoria INTEGER NOT NULL , 
     marca_id_marca INTEGER NOT NULL 
    )
GO*/
    public class Prenda
    {
        public int id_prenda { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public decimal precio { get; set; }
        public string ruta_imagen { get; set; }
        public string nombre_imagen { get; set; }
        public int usuario_id_usuario { get; set; }
        public int caregoria_id_categoria { get; set; }
        public int marca_id_marca { get; set; }
    }
}

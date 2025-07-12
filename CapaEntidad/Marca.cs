using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE comercio.marca 
    (
     id_marca INTEGER NOT NULL , 
     nombre VARCHAR (150) NOT NULL , 
     estado BIT NOT NULL 
    )
GO*/
    public class Marca
    {
        public int id_marca { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE administracion.rol 
    (
     id_rol INTEGER NOT NULL , 
     nombre VARCHAR (150) NOT NULL , 
     estado BIT NOT NULL 
    )
GO*/
    public class Rol
    {
        public int id_rol { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}

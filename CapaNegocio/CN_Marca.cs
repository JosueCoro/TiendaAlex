using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Marca
    {
        // Lista todas las marcas

        private CD_Marca marca = new CD_Marca();
        public List<Marca> Listar()
        {
            return marca.ListarMarcas();
        }

        // Agrega una nueva marca
        public int Registrar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre de la marca no puede ser vacio";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre de la marca no puede tener mas de 150 caracteres";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return marca.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }


        public bool Editar(Marca obj, out string Mensaje) { 
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre de la marca no puede ser vacio";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre de la marca no puede tener mas de 150 caracteres";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return marca.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool Eliminar(int id_marca, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool eliminado = marca.Eliminar(id_marca, out Mensaje);
            if (!eliminado)
            {
                Mensaje = "No se pudo eliminar la marca. " + Mensaje;
            }
            return eliminado;
        }
    }
}

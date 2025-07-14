using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCapaDato = new CD_Categoria();

        // Método para listar todas las categorías
        public List<Categoria> Listar()
        {
            return objCapaDato.ListarCategorias();
        }

        // Método para registrar una nueva categoría con validaciones
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty; // Inicializa el mensaje de salida

            // Validaciones de negocio para el nombre de la categoría
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre de la categoría no puede ser vacío";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre de la categoría no puede tener más de 150 caracteres";
            }

            // Si no hay mensajes de error de validación, procede a registrar en la capa de datos
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0; // Retorna 0 si la validación falla (no se generó ID)
            }
        }

        // Método para editar una categoría existente con validaciones
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty; // Inicializa el mensaje de salida

            // Validaciones de negocio para el nombre de la categoría (similar a Registrar)
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre de la categoría no puede ser vacío";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre de la categoría no puede tener más de 150 caracteres";
            }

            // Si no hay mensajes de error de validación, procede a editar en la capa de datos
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false; // Retorna false si la validación falla
            }
        }

        // Método para eliminar una categoría con validaciones de negocio
        public bool Eliminar(int id_categoria, out string Mensaje)
        {
            Mensaje = string.Empty; // Inicializa el mensaje de salida

            // Intenta eliminar la categoría en la capa de datos
            bool eliminado = objCapaDato.Eliminar(id_categoria, out Mensaje);

            // Si la eliminación no fue exitosa (por ejemplo, por dependencias en la BD)
            if (!eliminado)
            {
                // Sobrescribe el mensaje de error de la capa de datos con uno más específico para el usuario
                // (Asumiendo que el SP devuelve un mensaje claro de que está relacionado con prendas)
                Mensaje = "La categoría está relacionada con una o más prendas. No se puede eliminar.";
            }
            return eliminado; // Retorna el resultado de la operación
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Rol
    {
        private CD_Rol rol = new CD_Rol();

        // Lista todos los roles
        public List<Rol> Listar()
        {
            return rol.ListarRoles();
        }

        // Agrega un nuevo rol
        public int Registrar(Rol obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre del rol no puede ser vacio";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre del rol no puede tener mas de 150 caracteres";
            }
            else if (obj.estado == null)
            {
                Mensaje = "El estado del rol no puede ser nulo";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return rol.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Rol obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                Mensaje = "El nombre del rol no puede ser vacio";
            }
            else if (obj.nombre.Length > 150)
            {
                Mensaje = "El nombre del rol no puede tener mas de 150 caracteres";
            }
            else if (obj.estado == null)
            {
                Mensaje = "El estado del rol no puede ser nulo";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return rol.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id_rol, out string Mensaje)
        {
            Mensaje = string.Empty;

            bool eliminado = rol.Eliminar(id_rol, out Mensaje);
            if (!eliminado)
            {
                Mensaje = "El rol se encuentra relacionado a un usuario. No se puede eliminar.";
            }
            return eliminado;
        }

    }
}

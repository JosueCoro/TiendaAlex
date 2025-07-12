using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult Rol()
        {
            return View();
        }
        //Lista todos los roles
        [HttpGet]
        public ActionResult ListarRoles()
        {
            List<Rol> olista = new List<Rol>();
            olista = new CN_Rol().Listar();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRol(Rol objeto)
        {
            object resultado;
            string Mensaje = string.Empty;

            if (objeto.id_rol == 0)
            {
                resultado = new CN_Rol().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Rol().Editar(objeto, out Mensaje);
            }
            return Json(new { resultado = resultado, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarRol(int id)
        {
            bool respuesta = false;
            string Mensaje = string.Empty;
            respuesta = new CN_Rol().Eliminar(id, out Mensaje);
            return Json(new { resultado = respuesta, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
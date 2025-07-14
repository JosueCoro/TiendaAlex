using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Marca()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarMarcas()
        {
            List<Marca> olista = new List<Marca>();
            olista = new CN_Marca().Listar();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(Marca objeto)
        {
            object resultado;
            string Mensaje = string.Empty;
            if (objeto.id_marca == 0)
            {
                resultado = new CN_Marca().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Marca().Editar(objeto, out Mensaje);
            }
            return Json(new { resultado = resultado, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string Mensaje = string.Empty;
            respuesta = new CN_Marca().Eliminar(id, out Mensaje);
            return Json(new { resultado = respuesta, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Categoria()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarCategorias()
        {
            List<Categoria> olista = new List<Categoria>();
            olista = new CN_Categoria().Listar(); // Llama al método Listar de CN_Categoria
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {
            object resultado;
            string Mensaje = string.Empty;
            if (objeto.id_categoria == 0) // Verifica si es una nueva categoría
            {
                resultado = new CN_Categoria().Registrar(objeto, out Mensaje); // Llama a Registrar
            }
            else
            {
                resultado = new CN_Categoria().Editar(objeto, out Mensaje); // Llama a Editar
            }
            return Json(new { resultado = resultado, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string Mensaje = string.Empty;
            respuesta = new CN_Categoria().Eliminar(id, out Mensaje); // Llama a Eliminar
            return Json(new { resultado = respuesta, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Prenda()
        {
            return View();
        }
    }
}
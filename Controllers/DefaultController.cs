using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;
using Sistema_GGYM.Models.Base_De_Datos;

namespace Sistema_GGYM.Controllers
{
    public class DefaultController : Controller
    {
        PRODUCTO producto = new PRODUCTO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos()
        {
            return View(producto.ListarTodo());
        }

        public ActionResult AcercaDe()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }
    }
}
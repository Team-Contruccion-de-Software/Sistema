using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Sistema_GGYM.Filters.AdminFilters;
using Sistema_GGYM.Models.Base_De_Datos;
using Sistema_GGYM.Models;

namespace Sistema_GGYM.Controllers
{
    [Autenticado]
    public class ProductoController : Controller
    {
        PRODUCTO producto = new PRODUCTO();
        CATEGORIA_PRODUCTO categoria_producto = new CATEGORIA_PRODUCTO();

        public ActionResult Index()
        {
            return View(producto.ListarTodo());
        }

        public ActionResult Guardar(PRODUCTO producto)
        {
            if (ModelState.IsValid)
            {
                producto.RegistrarProducto();
                return Redirect("~/Producto");
            }
            else
            {
                return View("~/Producto");
            }
        }
    }
}
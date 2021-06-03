using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Sistema_GGYM.Filters.AdminFilters;

namespace Sistema_GGYM.Controllers
{
    [Autenticado]
    public class EjercicioController : Controller
    {
        // GET: Ejercicio
        public ActionResult Ejercicio()
        {
            return View();
        }
    }
}
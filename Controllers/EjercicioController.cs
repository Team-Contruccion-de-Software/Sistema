using Sistema_GGYM.Models;
using Sistema_GGYM.Models.Base_De_Datos;
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
        //Obtener imc del usuario
        VIDEO video = new VIDEO();
        IMC imc = new IMC();
        public ActionResult Ejercicio()
        {
            ViewBag.imc = imc.ObtenerIMC(SessionHelper.GetUser());
            ViewBag.video = video.ListarTodo();
            return View();
        }
    }
}
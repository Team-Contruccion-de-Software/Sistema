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
    public class UsuarioController : Controller
    {
        USUARIO usuario = new USUARIO();
        TIPO_USUARIO tipo_usuario = new TIPO_USUARIO();
        HORARIO horario = new HORARIO();
        REGISTRO registro = new REGISTRO();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuario.ListarTodo());
        }

        public ActionResult Calendario()
        {
            return View();
        }

        public ActionResult Horario()
        {
            ViewBag.registro = registro.ListarTodo();
            ViewBag.horario = horario.ListarTodo();
            return View(usuario.ListarTodo());
        }

        public ActionResult CoachHorario()
        {
            ViewBag.horario = horario.ListarTodo();
            return View(usuario.ListarTodo());
        }

        public ActionResult Videollamada()
        {
            return View();
        }

        public ActionResult EjerciciosRutinas()
        {
            return View();
        }

        public ActionResult RecetasDietas()
        {
            return View();
        }
    }
}
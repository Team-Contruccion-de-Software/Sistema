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
    public class AdministradorController : Controller
    {
        USUARIO usuario = new USUARIO();
        MEMBRESIA membresia = new MEMBRESIA();
        HORARIO horario = new HORARIO();

        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrenador()
        {
            return View(usuario.ListarTodo());
        }

        public ActionResult Membresia()
        {
            return View(membresia.ListarTodo());
        }

        public ActionResult Calendario()
        {
            return View(horario.ListarTodo());
        }



        /**************METODOS DE GUARDADO DE ENTRENADOR*****************************/
        public ActionResult Guardar(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistarEntrenador();
                return Redirect("~/Administrador/Entrenador");
            }
            else
            {
                return View("~/Administrador/Entrenador");
            }
        }

        /**************METODOS DE GUARDADO DE MEMBRESIA*****************************/
        public ActionResult GuardarMembresia(MEMBRESIA membresia)
        {
            if (ModelState.IsValid)
            {
                membresia.RegistrarMembresia();
                return Redirect("~/Administrador/Membresia");
            }
            else
            {
                return View("~/Administrador/Membresia");
            }
        }
    }
}
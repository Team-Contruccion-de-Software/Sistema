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
        MEMBRESIA membresia = new MEMBRESIA();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuario.ListarTodo());
        }

        /********METODOS PARA EL CALENDARIO*******/
        public ActionResult Calendario()
        {
            return View();
        }

        /********METODOS PARA LA MEMBRESIA*******/
        public ActionResult Membresia()
        {
            return View(membresia.ListarTodo());
        }

        public ActionResult GuardarMembresia(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistrarMembresia();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Usuario");
            }
        }


        /********METODOS PARA LOS HORARIOS DEL USUARIO*******/
        public ActionResult Horario()
        {
            ViewBag.registro = registro.ListarTodo();
            ViewBag.horario = horario.ListarTodo();
            return View(usuario.ListarTodo());
        }

        public ActionResult GuardarHorario(int idregistro, int iduser, int idhorario)
        {
            if (idregistro >= 0 && iduser > 0 && idhorario > 0)
            {
                registro.RegistarHorario(idregistro, iduser, idhorario);
                return Redirect("~/Usuario/Horario");
            }
            else
            {
                return View("/Usuario/Horario");
            }
        }



        /********METODOS PARA LOS HORARIOS DEL COACH*******/
        public ActionResult CoachHorario()
        {
            ViewBag.horario = horario.ListarTodo();
            return View(usuario.ListarTodo());
        }

        /********METODOS PARA LAS VIDEOLLAMADAS*******/
        public ActionResult Videollamada()
        {
            return View();
        }

        /********METODOS PARA LOS USUARIOS AL EDITAR SUS DATOS*******/
        public ActionResult Guardar(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistarCliente();
                return Redirect("~/Administrador/Index");
            }
            else
            {
                return View("~/Administrador/Index");
            }
        }
    }
}
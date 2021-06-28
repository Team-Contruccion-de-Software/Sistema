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
        PEDIDO pedido = new PEDIDO();
        REGISTRO registro = new REGISTRO();

        //Para reportes se usara el index        

        public ActionResult Index()
        {
            //Se retornaran con ViewBags
            /*****************Usuarios en el sistema*********************/
            //comunes   entrenadores    premium
            ViewBag.Reportecomunes = usuario.ListarComunes();
            ViewBag.Reporteentrenadores = usuario.ListarEntrenadores();
            ViewBag.Reportepremium = usuario.ListarPremium();

            /*****************Usuarios registrados a un horario y que horario es en el sistema*********************/
            ViewBag.ReporteHorarios = registro.ListarTodo();
            ViewBag.ReporteHelperHorario = horario.ListarTodo();

            /*****************Reporte de ventas*********************/
            ViewBag.ReporteGanancias = pedido.ListarTodo();
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



        /**************METODOS DE GUARDADO, EDICION Y ELIMINACION DEL ENTRENADOR*****************************/
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

        public ActionResult Eliminar(int id)
        {
            usuario.ID_USUARIO = id;
            usuario.Eliminar();
            return Redirect("~/Administrador/Entrenador");
        }

        public ActionResult Habilitar(int id)
        {
            usuario.ID_USUARIO = id;
            usuario.Habilitar();
            return Redirect("~/Administrador/Entrenador");
        }

        public ActionResult Edituser(int id = 0)
        {
            return View(id == 0 ? new USUARIO() : usuario.ObtenerUsuario(id));
        }

        /**************METODOS DE GUARDADO, EDICIO Y ELIMINADA DE LA MEMBRESIA*****************************/
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

        public ActionResult EliminarMem(int id)
        {
            membresia.ID_MEMBRESIA = id;
            membresia.Eliminar();
            return Redirect("~/Administrador/Membresia");
        }

        public ActionResult HabilitarMem(int id)
        {
            membresia.ID_MEMBRESIA = id;
            membresia.Habilitar();
            return Redirect("~/Administrador/Membresia");
        }

        public ActionResult EditMem(int id = 0)
        {
            return View(id == 0 ? new MEMBRESIA() : membresia.ObtenerMembresia(id));
        }
    }
}
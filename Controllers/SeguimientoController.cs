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
    public class SeguimientoController : Controller
    {
        USUARIO usuario = new USUARIO();
        SEGUIMIENTO seguimiento = new SEGUIMIENTO();
        IMC imc = new IMC();

        public ActionResult Seguimiento()
        {
            int idusuario = SessionHelper.GetUser();

            //datos del imc y del usuario
            ViewBag.Usuario = imc.ObtenerIMC(idusuario);

            //Obtener datos del seguimiento segun usuario
            return View(seguimiento.ObtenerSeguimientoDelUsuario(idusuario));
        }
    }
}
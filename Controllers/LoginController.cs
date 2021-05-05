using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;
using static Sistema_GGYM.Filters.AdminFilters;
using Sistema_GGYM.Models.Base_De_Datos;

namespace Sistema_GGYM.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO usuario = new USUARIO();
        private TIPO_USUARIO tipo_usuario = new TIPO_USUARIO();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormLogin()
        {
            return View();
        }

        public ActionResult IniciarSesion(string Email, string Contraseña)
        {
            var rm = usuario.ValidarLogin(Email, Contraseña);

            if (rm.response == true)
            {
                return View("../Default/Index");
            } 
            
            else
            {
                return View("Index");
            }            
        }
    }
}
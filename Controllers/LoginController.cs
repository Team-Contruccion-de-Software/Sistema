﻿using System;
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

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormLogin()
        {
            return View();
        }

        public ActionResult FormRegistro()
        {
            return View();
        }

        public ActionResult Validar(string Email, string Contraseña)
        {
            var rm = usuario.ValidarLogin(Email, Contraseña);

            if (rm.response == true && rm.idtipo < 4)
            {
                rm.href = Url.Content("/Usuario/Index");
            }
            else if (rm.response == true && rm.idtipo == 4)
            {
                rm.href = Url.Content("/Administrador/Index");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }

        public ActionResult Registrar(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistarCliente();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Login/Registro.cshtml", usuario);
            }
        }
    }
}
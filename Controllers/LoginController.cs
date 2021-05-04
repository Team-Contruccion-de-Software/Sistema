using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;

namespace Sistema_GGYM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult FormRegistro()
        {
            return View();
        }


        public ActionResult FormLogin()
        {
            return View();
        }
    }
}
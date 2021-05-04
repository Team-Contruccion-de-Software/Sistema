using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;

namespace Sistema_GGYM.Controllers
{
    public class DefaultController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
    }
}
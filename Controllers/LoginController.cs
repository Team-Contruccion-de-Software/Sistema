using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;
using static Sistema_GGYM.Filters.AdminFilters;
using Sistema_GGYM.Models.Base_De_Datos;

// Librerias para el correo 
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

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

        public ActionResult Recuperar()
        {
            return View();
        }

        public ActionResult FormRegistro()
        {
            return View();
        }

        public ActionResult RecuperarEmail(string Email)
        {
            EnviarCorreo(Email);
            return Redirect("~/Login/Index");
        }

        //Metodo para enviar el recibo de la compra de la membrecia
        public void EnviarCorreo(string Email)
        {
            var datos = usuario.ObtenerRespaldo(Email);

            string body =
                "<body>" +
                    "<h1>Bienvenido al sistema GGYM</h1>" +
                    "<h4>Hola " + datos.NOMBRE + " " + datos.APELLIDO + "</h4>" +
                    "<spam>Este es un mensaje de que usted realizo una peticion para recuperar su contraseña</spam>" +
                    "<br/><br/><spam>Su contraseña es: " + datos.PASSWORD + "</spam>" +
                "<body>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hakunaggym@gmail.com", "Computo.123"); //CREDENCIALES
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("hakunaggym@gmail.com", "Sistema GGYM"); //ORIGEN Y NOMBRE
            correo.To.Add(new MailAddress(Email, datos.NOMBRE + " " + datos.APELLIDO)); //DESTINO Y NOMBRE
            correo.Subject = "Recuperacion de contraseña"; //ASUNTO
            correo.IsBodyHtml = true;
            correo.Body = body;

            smtp.Send(correo);
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
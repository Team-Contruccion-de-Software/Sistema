using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Models;
using Sistema_GGYM.Filters;
using Sistema_GGYM.Models.Base_De_Datos;
using System.Net.Mail;
using System.Net;

namespace Sistema_GGYM.Controllers
{
    public class DefaultController : Controller
    {
        PRODUCTO producto = new PRODUCTO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos()
        {
            return View(producto.ListarTodo());
        }

        public ActionResult AcercaDe()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Enviar(string Email, string name, string Telefono, DateTime Fecha, string Mensaje)
        {
            string body =
                "<body>" +
                    "<h1>Mensaje de " + name + "</h1>" +
                    "<h5>Email emisor: " + Email + " , Telefono: " + Telefono + "</h5>" +
                    "<spam>Contenido del mensaje: " + Mensaje + "</spam>" +
                    "<br/><br/><spam>Enviado el dia: " + Fecha.ToString("dd/MM/yyyy") + "</spam>" +
                "<body>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hakunaggym@gmail.com", "Computo.123"); //CREDENCIALES
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("hakunaggym@gmail.com", "Sistema GGYM"); //ORIGEN Y NOMBRE
            correo.To.Add(new MailAddress("hakunaggym@gmail.com", "Sistema GGYM")); //DESTINO Y NOMBRE
            correo.Subject = "Mensajes del contacto"; //ASUNTO
            correo.IsBodyHtml = true;
            correo.Body = body;

            smtp.Send(correo);
            return Redirect("~/Default/Contacto");
        }
    }
}
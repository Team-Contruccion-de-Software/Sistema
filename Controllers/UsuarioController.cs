using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Sistema_GGYM.Filters.AdminFilters;
using Sistema_GGYM.Models.Base_De_Datos;
using Sistema_GGYM.Models;

// Librerias para el correo 
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

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
            ViewBag.registro = registro.ListarTodo();
            return View(horario.ListarTodo());
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
                EnviarCorreo(usuario);
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Usuario");
            }
        }

        //Metodo para enviar el recibo de la compra de la membrecia
        public void EnviarCorreo(USUARIO usuario)
        {
            string body =
                "<body>" +
                    "<h1>Bienvenido al sistema GGYM</h1>" +
                    "<h4>Hola " + usuario.NOMBRE + " " + usuario.APELLIDO + "</h4>" +
                    "<spam>Este es un mensaje de que usted realizo la compra correcta de una membresia para poder acceder a nuevas caracteristicas que el sistema ofrece</spam>" +
                    "<br/><br/><spam>Servidor de correos GGYM</spam>" +
                "<body>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hakunaggym@gmail.com", "Computo.123"); //CREDENCIALES
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("hakunaggym@gmail.com", "Sistema GGYM"); //ORIGEN Y NOMBRE
            correo.To.Add(new MailAddress(usuario.EMAIL, usuario.NOMBRE + " " + usuario.APELLIDO)); //DESTINO Y NOMBRE
            correo.Subject = "Compra de membresia"; //ASUNTO
            correo.IsBodyHtml = true;
            correo.Body = body;

            smtp.Send(correo);
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

        public ActionResult GuardarCoachHorario(HORARIO horario, string daterange, string hora)
        {
            

            if (!horario.DESCRIPCION.Equals("") && !daterange.Equals(""))
            {
                //split de la fecha
                string[] fechas = daterange.Split('-');
                horario.FECHA_INICIO = Convert.ToDateTime(fechas[0]);
                horario.FECHA_FIN = Convert.ToDateTime(fechas[1]);

                // aumentar 2 horas a la hora
                DateTime dateTime = new DateTime();
                string[] horas = hora.Split(':');
                horas[0] = (Convert.ToInt32(horas[0]) + 2).ToString();

                dateTime = DateTime.Parse(hora);
                horario.HORA_INICIO = dateTime.TimeOfDay;

                dateTime = DateTime.Parse(horas[0] + ":" + horas[1]);
                horario.HORA_FIN = dateTime.TimeOfDay;

                horario.RegistrarHorario();
                return Redirect("~/Usuario/CoachHorario");
            }
            else
            {
                return View("/Usuario/CoachHorario");
            }
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

                if (usuario.ID_TIPOUSUARIO == 4)
                {
                    return Redirect("~/Administrador/Index");
                }
                else
                {
                    return Redirect("~/Usuario/Index");
                }
                
                
            }
            else
            {
                if (usuario.ID_TIPOUSUARIO == 4)
                {
                    return Redirect("~/Administrador/Index");
                }
                else
                {
                    return Redirect("~/Usuario/Index");
                }
            }
        }
    }
}
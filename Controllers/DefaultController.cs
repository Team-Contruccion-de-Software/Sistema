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
        private CATEGORIA_PRODUCTO categoria_producto = new CATEGORIA_PRODUCTO();
        private PRODUCTO producto = new PRODUCTO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos()
        {
            if (TempData["Carrito"] != null)
            {
                decimal x = 0;
                List<Carrito> li2 = TempData["Carrito"] as List<Carrito>;
                TempData["total"] = li2.Count();
                foreach (var item in li2)
                {
                    x += item.total;
                }
                TempData["TotalaPagar"] = x;
            }

            TempData.Keep();

            ViewBag.Categoria = categoria_producto.Listar();
            ViewBag.ProductoTodos = producto.ListarTodo();
            return View();
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

        public ActionResult ProductoDetalle(int id)
        {
            ViewBag.Categoria = categoria_producto.Listar();
            return View(producto.ObtenerDetalle(id));
        }

        public ActionResult ProductoCategoria(int id)
        {
            ViewBag.Categoria = categoria_producto.Listar();
            ViewBag.ProductoCategorias = producto.ListarPorCategoria(id);
            return View(producto.ListarPorCategoria(id));
        }

        //Aqui empieza lo del carrito

        List<Carrito> li = new List<Carrito>();

        public ActionResult Adtocart(PRODUCTO producto)
        {
            var p = new PRODUCTO().ObtenerProducto(producto.ID_PRODUCTO);
            Carrito c = new Carrito();
            c.productid = p.ID_PRODUCTO;
            c.productname = p.DESCRIPCION;
            c.precio = p.PRECIO;
            c.cantidad = Convert.ToInt32(Request.Form["cantidad"]);
            c.total = c.precio * c.cantidad;
            c.imagen = p.IMAGEN;

            if (TempData["Carrito"] == null)
            {
                li.Add(c);
                TempData["Carrito"] = li;
            }
            else
            {
                List<Carrito> li2 = TempData["Carrito"] as List<Carrito>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.productid == c.productid)
                    {
                        item.cantidad += c.cantidad;
                        item.precio += c.precio;
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    li2.Add(c);
                }

                TempData["Carrito"] = li2;
            }

            TempData.Keep();

            return RedirectToAction("Productos");
        }

        public ActionResult ListarCarrito(PRODUCTO producto)
        {
            TempData.Keep();
            ViewBag.Categoria = categoria_producto.Listar();
            return View();
        }

        public ActionResult Remover(int id)
        {
            List<Carrito> li2 = TempData["Carrito"] as List<Carrito>;
            Carrito c = li2.Where(x => x.productid == id).SingleOrDefault();
            li2.Remove(c);
            decimal h = 0;
            foreach (var item in li2)
            {
                h += item.total;
            }
            TempData["TotalaPagar"] = h;
            return RedirectToAction("ListarCarrito");
        }

        public ActionResult GuardarPedido(PRODUCTO O)
        {
            DateTime now = DateTime.Now;
            Random rnd = new Random();

            List<Carrito> li = TempData["Carrito"] as List<Carrito>;
            PEDIDO pedido = new PEDIDO();
            pedido.ID_USUARIO = SessionHelper.GetUser();
            pedido.FECHA = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
            pedido.TOTAL = (decimal)TempData["TotalaPagar"];
            pedido.ESTADO = false;
            pedido.NUMERO_PEDIDO = "P-" + rnd.Next(1, 10);
            pedido.Guardar(pedido);

            foreach (var item in li)
            {
                DETALLE_PEDIDO detalle = new DETALLE_PEDIDO();
                detalle.ID_PRODUCTO = item.productid;
                detalle.ID_PEDIDO = pedido.ID_PEDIDO;
                detalle.SUBTOTAL = item.total;
                detalle.CANTIDAD = item.cantidad.ToString();
                detalle.Guardar(detalle);
            }

            TempData.Remove("total");
            TempData.Remove("Carrito");
            TempData.Remove("TotalaPagar");

            TempData["mensaje"] = "  Pedido realizado con exito.....";
            TempData.Keep();
            return RedirectToAction("Productos");
        }
    }
}
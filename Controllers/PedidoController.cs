using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_GGYM.Filters;
using Sistema_GGYM.Models;
using Sistema_GGYM.Models.Base_De_Datos;
using static Sistema_GGYM.Filters.AdminFilters;

namespace Sistema_GGYM.Controllers
{
    [Autenticado]
    public class PedidoController : Controller
    {
        private PEDIDO pedido = new PEDIDO();
        private DETALLE_PEDIDO detalle_pedido = new DETALLE_PEDIDO();

        // GET: Pedido
        public ActionResult Index()
        {
            Sistema_GGYM.Models.Base_De_Datos.USUARIO usuario = new Sistema_GGYM.Models.Base_De_Datos.USUARIO().ObtenerUsuario((Sistema_GGYM.Models.SessionHelper.GetUser()));
            return View(pedido.ListarTodo());
        }
        public ActionResult Ver(int id)
        {
            ViewBag.Pedidos = detalle_pedido.Listar(id);
            return View(pedido.Obtener(id));
        }

        public ActionResult Editar(int id)
        {
            //MODIFICA EL ESTADO DEL PEDIDO
            foreach (var item in pedido.ListarTodo())
            {
                if (id == item.ID_PEDIDO)
                {
                    pedido.ID_PEDIDO = id;
                    pedido.NUMERO_PEDIDO = item.NUMERO_PEDIDO;
                    pedido.NUMERO_PEDIDO = item.NUMERO_PEDIDO;
                    pedido.FECHA = item.FECHA;
                    pedido.TOTAL = item.TOTAL;
                    pedido.ID_USUARIO = item.ID_USUARIO;
                    pedido.ESTADO = true;
                }
            }
            pedido.Editar(pedido);


            //MODIFICAR EL STOCK DE LOS PRODUCTOS
            DETALLE_PEDIDO detalle_pedido = new DETALLE_PEDIDO();
            PRODUCTO producto = new PRODUCTO();

            foreach (var detalle in detalle_pedido.Listar(id))
            {
                //descontar al producto
                foreach (var pro in producto.ListarTodo())
                {
                    if (detalle.ID_PRODUCTO == pro.ID_PRODUCTO)
                    {
                        producto.ID_PRODUCTO = pro.ID_PRODUCTO;
                        producto.CODIGO = pro.CODIGO;
                        producto.DESCRIPCION = pro.DESCRIPCION;
                        producto.PRECIO = pro.PRECIO;
                        producto.IMAGEN = pro.IMAGEN;
                        producto.ID_CATEGORIA = pro.ID_CATEGORIA;

                        //mandar la lista actualizada - modificar tabla producto
                        producto.STOCK = pro.STOCK - Convert.ToInt32(detalle.CANTIDAD);
                        producto.Editar(producto);
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
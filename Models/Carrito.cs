using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_GGYM.Models
{
    public class Carrito
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }
        public string imagen { get; set; }
    }
}
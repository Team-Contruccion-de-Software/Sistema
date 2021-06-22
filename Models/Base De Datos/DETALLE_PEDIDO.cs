namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class DETALLE_PEDIDO
    {
        [Key]
        public int ID_DETALLE_PEDIDO { get; set; }

        [Required]
        [StringLength(20)]
        public string CANTIDAD { get; set; }

        public decimal SUBTOTAL { get; set; }

        public int ID_PEDIDO { get; set; }

        public int ID_PRODUCTO { get; set; }

        public virtual PEDIDO PEDIDO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }

        public List<DETALLE_PEDIDO> Listar(int aux)
        {
            var detalle_pedidos = new List<DETALLE_PEDIDO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    detalle_pedidos = db.DETALLE_PEDIDO.Include("PRODUCTO").Include("PEDIDO")
                        .Where(x => x.ID_PEDIDO == aux).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return detalle_pedidos;
        }

        internal void Guardar(DETALLE_PEDIDO detalle)
        {
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_DETALLE_PEDIDO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        this.ID_PRODUCTO = detalle.ID_PRODUCTO;
                        this.ID_PEDIDO = detalle.ID_PEDIDO;
                        this.SUBTOTAL = detalle.SUBTOTAL;
                        this.CANTIDAD = detalle.CANTIDAD;
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

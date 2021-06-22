namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("PEDIDO")]
    public partial class PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int ID_PEDIDO { get; set; }

        [Required]
        [StringLength(20)]
        public string NUMERO_PEDIDO { get; set; }

        public DateTime? FECHA { get; set; }

        public decimal TOTAL { get; set; }

        public int ID_USUARIO { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

     
        public List<PEDIDO> ListarTodo()
        {
            var pedidos = new List<PEDIDO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    pedidos = db.PEDIDO.Include("USUARIO")
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return pedidos;
        }


        public List<PEDIDO> Buscar(string criterio)
        {
            var pedidos = new List<PEDIDO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    pedidos = db.PEDIDO.Include("USUARIO")
                        .Where(x => x.FECHA.ToString().Contains(criterio) ||
                               x.NUMERO_PEDIDO.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return pedidos;
        }

        public PEDIDO Obtener(int id)
        {
            var pedido = new PEDIDO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    pedido = db.PEDIDO.Include("USUARIO")
                        .Where(x => x.ID_PEDIDO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pedido;
        }


        public void Guardar(PEDIDO pedido)
        {
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_PEDIDO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        this.ID_USUARIO = pedido.ID_USUARIO;
                        this.FECHA = pedido.FECHA;
                        this.TOTAL = pedido.TOTAL;
                        this.ESTADO = pedido.ESTADO;
                        this.NUMERO_PEDIDO = pedido.NUMERO_PEDIDO;
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


        public void Editar(PEDIDO pedido)
        {
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_PEDIDO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public List<PEDIDO> ListarPedidoPorCliente(int aux)
        {
            var pedidos = new List<PEDIDO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    pedidos = db.PEDIDO.Include("USUARIO")
                        .Where(x => x.ID_USUARIO == aux).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return pedidos;
        }
    }
}

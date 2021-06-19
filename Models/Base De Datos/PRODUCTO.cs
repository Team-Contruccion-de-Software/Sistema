namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
            REPORTES = new HashSet<REPORTES>();
        }

        [Key]
        public int ID_PRODUCTO { get; set; }

        [Required]
        [StringLength(10)]
        public string CODIGO { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        public int STOCK { get; set; }

        public decimal PRECIO { get; set; }

        public string IMAGEN { get; set; }

        public int ID_CATEGORIA { get; set; }

        public virtual CATEGORIA_PRODUCTO CATEGORIA_PRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTES> REPORTES { get; set; }

        public List<PRODUCTO> ListarTodo()
        {
            var productos = new List<PRODUCTO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    productos = db.PRODUCTO.Include("CATEGORIA_PRODUCTO").ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return productos;
        }

        public void RegistrarProducto()
        {
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_PRODUCTO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
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

        public PRODUCTO ObtenerProducto(int id)
        {
            var producto = new PRODUCTO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    producto = db.PRODUCTO.Include("CATEGORIA_PRODUCTO")
                        .Where(x => x.ID_PRODUCTO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return producto;
        }
    }
}

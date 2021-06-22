namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class CATEGORIA_PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA_PRODUCTO()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        [Key]
        public int ID_CATEGORIA { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        public List<CATEGORIA_PRODUCTO> Listar()
        {
            var categoria = new List<CATEGORIA_PRODUCTO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    categoria = db.CATEGORIA_PRODUCTO.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return categoria;
        }
    }
}

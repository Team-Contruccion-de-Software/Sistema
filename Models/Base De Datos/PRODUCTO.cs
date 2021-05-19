namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
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
        public virtual ICollection<REPORTES> REPORTES { get; set; }
    }
}

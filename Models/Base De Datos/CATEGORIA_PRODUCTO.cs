namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}

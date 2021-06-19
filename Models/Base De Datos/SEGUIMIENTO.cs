namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEGUIMIENTO")]
    public partial class SEGUIMIENTO
    {
        [Key]
        public int ID_SEGUIMIENTO { get; set; }

        public int? ID_USUARIO { get; set; }

        [StringLength(8)]
        public string PESO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}

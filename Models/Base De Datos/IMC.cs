namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMC")]
    public partial class IMC
    {
        [Key]
        public int ID_IMC { get; set; }

        public int? ID_USUARIO { get; set; }

        [Column("IMC")]
        [StringLength(8)]
        public string IMC1 { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}

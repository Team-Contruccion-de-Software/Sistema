namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIDEO")]
    public partial class VIDEO
    {
        [Key]
        public int ID_VIDEO { get; set; }

        [StringLength(40)]
        public string TITULO { get; set; }

        [StringLength(80)]
        public string DESCRIPCION { get; set; }

        [StringLength(200)]
        public string URL { get; set; }

        [StringLength(20)]
        public string CRITERIO { get; set; }

        public int? ID_TIPOVIDEO { get; set; }

        public virtual TIPO_VIDEO TIPO_VIDEO { get; set; }
    }
}

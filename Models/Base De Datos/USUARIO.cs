namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [StringLength(40)]
        public string DIRECCION { get; set; }

        [StringLength(8)]
        public string PESO { get; set; }

        [StringLength(8)]
        public string ESTATURA { get; set; }

        [StringLength(5)]
        public string EDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}

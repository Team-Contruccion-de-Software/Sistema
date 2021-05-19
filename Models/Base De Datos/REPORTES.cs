namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REPORTES
    {
        [Key]
        public int ID_REPORTE { get; set; }

        public DateTime? FECHA { get; set; }

        public int? ID_PRODUCTO { get; set; }

        public int? ID_USUARIO { get; set; }

        public int? ID_MEMBRESIA { get; set; }

        public int? ID_HORARIO { get; set; }

        public virtual HORARIO HORARIO { get; set; }

        public virtual MEMBRESIA MEMBRESIA { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}

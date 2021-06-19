namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_PEDIDO
    {
        [Key]
        public int ID_DETALLE_PEDIDO { get; set; }

        [Required]
        [StringLength(20)]
        public string CANTIDAD { get; set; }

        public decimal SUBTOTAL { get; set; }

        public int ID_PEDIDO { get; set; }

        public int ID_PRODUCTO { get; set; }

        public virtual PEDIDO PEDIDO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}

namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HORARIO")]
    public partial class HORARIO
    {
        [Key]
        public int ID_HORARIO { get; set; }

        [Required]
        [StringLength(500)]
        public string DESCRIPCION { get; set; }

        public TimeSpan HORA_INICIO { get; set; }

        public TimeSpan HORA_FIN { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        public int? ID_USUARIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        public List<HORARIO> ListarTodo()
        {
            var horario = new List<HORARIO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    horario = db.HORARIO.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return horario;
        }
    }
}

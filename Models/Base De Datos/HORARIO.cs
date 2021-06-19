namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HORARIO")]
    public partial class HORARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HORARIO()
        {
            REGISTRO = new HashSet<REGISTRO>();
            REPORTES = new HashSet<REPORTES>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTES> REPORTES { get; set; }

        public List<HORARIO> ListarTodo()
        {
            var horario = new List<HORARIO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    horario = db.HORARIO.Include("REGISTRO").ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return horario;
        }


        public void RegistrarHorario()
        {
            try
            {
                using (var db = new ModeloGGYM())
                {
                    db.Entry(this).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

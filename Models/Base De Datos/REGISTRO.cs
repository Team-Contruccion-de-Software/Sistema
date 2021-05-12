namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("REGISTRO")]
    public partial class REGISTRO
    {
        [Key]
        public int ID_REGISTRO { get; set; }

        public int? ID_USUARIO { get; set; }

        public int? ID_HORARIO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public virtual HORARIO HORARIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }


        public List<REGISTRO> ListarTodo()
        {
            var registro = new List<REGISTRO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    registro = db.REGISTRO.Include("USUARIO").Include("HORARIO")
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return registro;
        }
    }
}

namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
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


        public void RegistarHorario(int idregistro, int iduser, int idhorario)
        {
            DateTime now = DateTime.Now;
            this.FECHA_CREACION = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
            this.ID_USUARIO = iduser;
            this.ID_HORARIO = idhorario;
            this.ID_REGISTRO = idregistro;

            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_REGISTRO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {                        
                        db.Entry(this).State = EntityState.Added;
                    }
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

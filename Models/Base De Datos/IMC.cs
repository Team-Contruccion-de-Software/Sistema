namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        public IMC ObtenerIMC(int idusuario)
        {
            var imcchiquito = new IMC();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    imcchiquito = db.IMC
                        .Where(x => x.ID_USUARIO == idusuario)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return imcchiquito;
        }

        public void RegistrarIMC(int idusuario, string imcTemporal)
        {
            var imcchiquito = ObtenerIMC(idusuario);
            this.ID_USUARIO = idusuario;
            this.IMC1 = imcTemporal;

            if (imcchiquito == null)
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
            else
            {
                this.ID_IMC = imcchiquito.ID_IMC;

                try
                {
                    using (var db = new ModeloGGYM())
                    {
                        db.Entry(this).State = EntityState.Modified;
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
}

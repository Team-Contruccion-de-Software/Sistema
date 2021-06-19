namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SEGUIMIENTO")]
    public partial class SEGUIMIENTO
    {
        [Key]
        public int ID_SEGUIMIENTO { get; set; }

        public int? ID_USUARIO { get; set; }

        [StringLength(8)]
        public string PESO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA { get; set; }

        public virtual USUARIO USUARIO { get; set; }


        public SEGUIMIENTO ObtenerSeguimiento(int id)
        {
            var seguimiento = new SEGUIMIENTO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    seguimiento = db.SEGUIMIENTO
                        .Where(x => x.ID_SEGUIMIENTO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return seguimiento;
        }

        public SEGUIMIENTO ObtenerSeguimientoPorFecha(DateTime diahoy, int id)
        {
            var seguimiento = new SEGUIMIENTO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    seguimiento = db.SEGUIMIENTO
                        .Where(x => x.FECHA.Value == diahoy && x.ID_USUARIO == id )
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return seguimiento;
        }

        public void RegistarSeguimiento(int idusuario, string pesousuario)
        {
            //EL DIA DE HOY
            DateTime now = DateTime.Now;
            now = Convert.ToDateTime(now.ToString("dd/MM/yyyy"));

            var seguimiento = ObtenerSeguimientoPorFecha(now, idusuario);
            this.ID_USUARIO = idusuario;
            this.PESO = pesousuario;

            if (seguimiento == null)
            {
                // SIGNIFICA QUE ES UN NUEVO DATO
                this.FECHA = Convert.ToDateTime(now.ToString("dd/MM/yyyy"));                

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
                // NO HACE NADA PORQUE SIGNIFICA QUE SON IGUALES
                // QUEDARIA COMPARAR LOS PESOS SI NO SON IGUALES PARA ACTUALIZAR
                if (!this.PESO.Equals(seguimiento.PESO))
                {
                    this.ID_SEGUIMIENTO = seguimiento.ID_SEGUIMIENTO;
                    this.ID_USUARIO = seguimiento.ID_USUARIO;
                    this.FECHA = seguimiento.FECHA;

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
                else
                {
                    // AHORA SI NO HACE NADA
                }
            }
        }
    }
}

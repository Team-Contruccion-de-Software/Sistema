namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("MEMBRESIA")]
    public partial class MEMBRESIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEMBRESIA()
        {
            REPORTES = new HashSet<REPORTES>();
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int ID_MEMBRESIA { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCRIPCION { get; set; }

        public int? DURACION { get; set; }

        [StringLength(10)]
        public string COSTO { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTES> REPORTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<MEMBRESIA> ListarTodo()
        {
            var membresia = new List<MEMBRESIA>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    membresia = db.MEMBRESIA.OrderBy(x => x.COSTO).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return membresia;
        }

        public void RegistrarMembresia()
        {
            this.ESTADO = true;

            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_MEMBRESIA > 0)
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

        public MEMBRESIA ObtenerMembresia(int id)
        {
            var membresia = new MEMBRESIA();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    membresia = db.MEMBRESIA
                        .Where(x => x.ID_MEMBRESIA == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return membresia;
        }


        public void Eliminar()
        {
            var membresia = ObtenerMembresia(ID_MEMBRESIA);
            this.ID_MEMBRESIA = membresia.ID_MEMBRESIA;
            this.DESCRIPCION = membresia.DESCRIPCION;
            this.DURACION = membresia.DURACION;
            this.COSTO = membresia.COSTO;
            this.ESTADO = false;
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_MEMBRESIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Habilitar()
        {
            var membresia = ObtenerMembresia(ID_MEMBRESIA);
            this.ID_MEMBRESIA = membresia.ID_MEMBRESIA;
            this.DESCRIPCION = membresia.DESCRIPCION;
            this.DURACION = membresia.DURACION;
            this.COSTO = membresia.COSTO;
            this.ESTADO = true;
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_MEMBRESIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
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

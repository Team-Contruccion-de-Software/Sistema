using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sistema_GGYM.Models.Base_De_Datos
{
    public partial class ModeloGGYM : DbContext
    {
        public ModeloGGYM()
            : base("name=ModeloGGYM")
        {
        }

        public virtual DbSet<CATEGORIA_PRODUCTO> CATEGORIA_PRODUCTO { get; set; }
        public virtual DbSet<HORARIO> HORARIO { get; set; }
        public virtual DbSet<MEMBRESIA> MEMBRESIA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<REGISTRO> REGISTRO { get; set; }
        public virtual DbSet<REPORTES> REPORTES { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.CATEGORIA_PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HORARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBRESIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBRESIA>()
                .Property(e => e.COSTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.IMAGEN)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .HasForeignKey(e => e.ID_TIPOUSUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PESO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.ESTATURA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EDAD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);
        }
    }
}

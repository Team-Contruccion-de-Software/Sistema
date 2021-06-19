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
        public virtual DbSet<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public virtual DbSet<HORARIO> HORARIO { get; set; }
        public virtual DbSet<IMC> IMC { get; set; }
        public virtual DbSet<MEMBRESIA> MEMBRESIA { get; set; }
        public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<REGISTRO> REGISTRO { get; set; }
        public virtual DbSet<REPORTES> REPORTES { get; set; }
        public virtual DbSet<SEGUIMIENTO> SEGUIMIENTO { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<TIPO_VIDEO> TIPO_VIDEO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VIDEO> VIDEO { get; set; }

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

            modelBuilder.Entity<DETALLE_PEDIDO>()
                .Property(e => e.CANTIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_PEDIDO>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HORARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<IMC>()
                .Property(e => e.IMC1)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBRESIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBRESIA>()
                .Property(e => e.COSTO)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.NUMERO_PEDIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.TOTAL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PEDIDO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PEDIDO)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEGUIMIENTO>()
                .Property(e => e.PESO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .HasForeignKey(e => e.ID_TIPOUSUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPO_VIDEO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

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

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PEDIDO)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.CRITERIO)
                .IsUnicode(false);
        }
    }
}

namespace Sistema_GGYM.Models.Base_De_Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            HORARIO = new HashSet<HORARIO>();
            IMC = new HashSet<IMC>();
            PEDIDO = new HashSet<PEDIDO>();
            REGISTRO = new HashSet<REGISTRO>();
            REPORTES = new HashSet<REPORTES>();
            SEGUIMIENTO = new HashSet<SEGUIMIENTO>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [StringLength(40)]
        public string DIRECCION { get; set; }

        [StringLength(8)]
        public string PESO { get; set; }

        [StringLength(8)]
        public string ESTATURA { get; set; }

        [StringLength(5)]
        public string EDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(80)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public int? ID_MEMBRESIA { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HORARIO> HORARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMC> IMC { get; set; }

        public virtual MEMBRESIA MEMBRESIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTES> REPORTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEGUIMIENTO> SEGUIMIENTO { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }

        public List<USUARIO> ListarTodo()
        {
            var usuarios = new List<USUARIO>();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO").ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return usuarios;
        }

        public List<USUARIO> ListarComunes()
        {
            var usuarios = new List<USUARIO>();
            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_TIPOUSUARIO == 1)
                        .ToList();
                }
            } catch (Exception e)
            {
                throw;
            }
            return usuarios;
        }

        public List<USUARIO> ListarEntrenadores()
        {
            var usuarios = new List<USUARIO>();
            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_TIPOUSUARIO == 3)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return usuarios;
        }

        public List<USUARIO> ListarPremium()
        {
            var usuarios = new List<USUARIO>();
            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_TIPOUSUARIO == 2)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return usuarios;
        }


        public ResponseModel ValidarLogin(string Usuario, string Contrase?a)
        {
            var rm = new ResponseModel();
            Contrase?a = HashHelper.SHA1(Contrase?a);

            try
            {
                using (var db = new ModeloGGYM())
                {
                    //Contrase?a = HashHelper.SHA1(Contrase?a);

                    var usuario = db.USUARIO.Where(x => x.EMAIL == Usuario)
                        .Where(x => x.PASSWORD == Contrase?a)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.ID_USUARIO.ToString());
                        rm.SetResponse(true);
                        rm.idtipo = usuario.ID_TIPOUSUARIO;
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }


        public void RegistarCliente()
        {
            this.ESTADO = true;
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        this.PASSWORD = HashHelper.SHA1(this.PASSWORD);
                        this.ID_TIPOUSUARIO = 1;
                        this.FECHA_CREACION = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
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

        public void RegistarEntrenador()
        {
            this.ESTADO = true;

            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        this.PASSWORD = HashHelper.SHA1(this.PASSWORD);
                        this.ID_TIPOUSUARIO = 3;
                        this.FECHA_CREACION = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
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

        public void RegistrarMembresia()
        {
            this.ESTADO = true;

            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        this.ID_TIPOUSUARIO = 2;
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


        public USUARIO ObtenerUsuario(int id)
        {
            var usuario = new USUARIO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuario = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_USUARIO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public USUARIO ObtenerRespaldo(string EmailRecuperar)
        {
            var usuario = new USUARIO();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    usuario = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.EMAIL == EmailRecuperar)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }


        public void Eliminar()
        {
            var usuario = ObtenerUsuario(ID_USUARIO);
            this.ID_USUARIO = usuario.ID_USUARIO;
            this.NOMBRE = usuario.NOMBRE;
            this.APELLIDO = usuario.APELLIDO;
            this.FECHA_CREACION = usuario.FECHA_CREACION;
            this.TELEFONO = usuario.TELEFONO;
            this.DIRECCION = usuario.DIRECCION;
            this.PESO = usuario.PESO;
            this.ESTATURA = usuario.ESTATURA;
            this.EDAD = usuario.EDAD;
            this.EMAIL = usuario.EMAIL;
            this.PASSWORD = usuario.PASSWORD;
            this.ID_TIPOUSUARIO = usuario.ID_TIPOUSUARIO;
            this.ID_MEMBRESIA = usuario.ID_MEMBRESIA;
            this.ESTADO = false;
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_USUARIO > 0)
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
            var usuario = ObtenerUsuario(ID_USUARIO);
            this.ID_USUARIO = usuario.ID_USUARIO;
            this.NOMBRE = usuario.NOMBRE;
            this.APELLIDO = usuario.APELLIDO;
            this.FECHA_CREACION = usuario.FECHA_CREACION;
            this.TELEFONO = usuario.TELEFONO;
            this.DIRECCION = usuario.DIRECCION;
            this.PESO = usuario.PESO;
            this.ESTATURA = usuario.ESTATURA;
            this.EDAD = usuario.EDAD;
            this.EMAIL = usuario.EMAIL;
            this.PASSWORD = usuario.PASSWORD;
            this.ID_TIPOUSUARIO = usuario.ID_TIPOUSUARIO;
            this.ID_MEMBRESIA = usuario.ID_MEMBRESIA;
            this.ESTADO = true;
            try
            {
                using (var db = new ModeloGGYM())
                {
                    if (this.ID_USUARIO > 0)
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

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
        [StringLength(50)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public int? ID_HORARIO { get; set; }

        public virtual HORARIO HORARIO { get; set; }

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


        public ResponseModel ValidarLogin(string Usuario, string Contraseña)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloGGYM())
                {
                    //Contraseña = HashHelper.SHA1(Contraseña);

                    var usuario = db.USUARIO.Where(x => x.EMAIL == Usuario)
                        .Where(x => x.PASSWORD == Contraseña)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.ID_USUARIO.ToString());
                        rm.SetResponse(true);
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
            DateTime now = DateTime.Now;
            this.ID_TIPOUSUARIO = 1;

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
    }
}

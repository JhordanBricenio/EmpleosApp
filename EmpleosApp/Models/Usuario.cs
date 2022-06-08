using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{

    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Username es requerido")]
        [StringLength(8, ErrorMessage = "la longitud debe estar entre 8 y 3 caracteres.", MinimumLength = 3)]
        public string Username { get; set; }
        

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(45, ErrorMessage = "El campo Nombre no puede tener mas de 45 caracteres")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        public String Nombre { get; set; }
        

        [Required (ErrorMessage = "El campo Email es requerido")]
        [EmailAddress]
        public string Email { get; set; }
        

        [Required (ErrorMessage = "El campo Password es requerido")]
        [MaxLength(50, ErrorMessage = "El campo Password no puede tener mas de 50 caracteres")]
        [MinLength(5, ErrorMessage = "El Password debe tener al menos 5 caracteres")]
        public string Password { get; set; }

        [Required]
        public int Estado { get; set; }

        [DisplayName("Fecha de Registro")]
        [Required (ErrorMessage = "El campo es requerido")]
        
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("IdUsuario")]
        public List<UsuarioPerfil>? Perfiles { get; set; }

        [NotMapped]
        public  List<Perfil>? Perfile { get; set; }

        // Metodo para agregar perfiles
        public void agregar(Perfil tempPerfil)
        {
            if (Perfile == null)
            {
                Perfile = new List<Perfil>();
            }
            Perfile.Add(tempPerfil);
        }
        // Metodo para agregar perfiles


    }
}

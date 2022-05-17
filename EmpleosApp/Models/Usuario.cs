using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{

    [Table("Usuarios")]
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public String Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        
        public int Estado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public List<Perfil> Perfiles { get; set; }

    }
}

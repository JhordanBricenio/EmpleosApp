using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{


    [Table("Perfiles")]
    public class Perfil
    {
        public int Id { get; set; }
        public string perfil { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}

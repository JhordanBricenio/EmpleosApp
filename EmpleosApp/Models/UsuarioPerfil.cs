using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{
    [Table("usuarioPerfil")]
    public class UsuarioPerfil
    {
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Column("idPerfil")]
        public int IdPerfil { get; set; }

        public Usuario Usuario { get; set; }

        public Perfil Perfil { get; set; }
    }
}

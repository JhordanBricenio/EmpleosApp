using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{
    [Table("usuarioPerfil")]
    public partial class UsuarioPerfil
    {
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Column("idPerfil")]
        public int IdPerfil { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual Perfil? Perfil { get; set; }

        
    }
}

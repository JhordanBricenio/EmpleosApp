using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpleosApp.Models.Mapping
{
    public class PerfilesMapping : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.ToTable("usuarioPerfil");
            builder.HasKey(o => new { o.IdPerfil,o.IdUsuario} );
        }
    }
}

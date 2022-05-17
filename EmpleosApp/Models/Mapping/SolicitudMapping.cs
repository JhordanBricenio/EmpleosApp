using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpleosApp.Models.Mapping
{
    public class SolicitudMapping : IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            builder.ToTable("Solicitudes");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.IdUsuario);

            builder.HasOne(o => o.Vacante)
                .WithMany()
                .HasForeignKey(o => o.IdVacante);
        }
    }
}

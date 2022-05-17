using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpleosApp.Models.Mapping
{
    public class VacanteMapping : IEntityTypeConfiguration<Vacante>
    {
        public void Configure(EntityTypeBuilder<Vacante> builder)
        {
            builder.ToTable("Vacantes");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Categorias)
                .WithMany()
                .HasForeignKey(o => o.IdCategoria);
        }
    }
}

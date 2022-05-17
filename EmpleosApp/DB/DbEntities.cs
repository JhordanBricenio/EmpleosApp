using EmpleosApp.Models;
using EmpleosApp.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.DB
{
    public partial class DbEntities: DbContext
    {
        public DbEntities() { }


        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new PerfilesMapping());
            modelBuilder.ApplyConfiguration(new SolicitudMapping());
            modelBuilder.ApplyConfiguration(new VacanteMapping());

        }


        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Solicitud> Solicitudes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Vacante> Vacantes { get; set; }
    }
}


using Microsoft.EntityFrameworkCore;
using ApiAsistencia.Entity;


namespace ApiAsistencia.Controllers

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Asist_Usuarios> Asist_Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Asist_Usuario y Usuario
            modelBuilder.Entity<Asist_Usuarios>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Asistencias)
                .HasForeignKey(a => a.Id_Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

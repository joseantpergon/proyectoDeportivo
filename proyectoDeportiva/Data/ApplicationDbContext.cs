using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using proyectoDeportiva.Areas.Identity.Data;

namespace proyectoDeportiva.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("user");
            builder.Entity<Reserva>().ToTable("reserva");
            builder.Entity<Pista>().ToTable("pista");
            builder.Entity<TipoDeporte>().ToTable("tipodeporte");
            builder.Entity<Estado>().ToTable("estado");
        }


        public DbSet<User>? Users { get; set; }

        public DbSet<Reserva>? Reservas { get; set; }
        public DbSet<Pista>? Pistas { get; set; }
        public DbSet<TipoDeporte>? TipoDeportes { get; set; }
        public DbSet<Estado>? Estados { get; set; }

    }
}
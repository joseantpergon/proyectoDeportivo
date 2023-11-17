using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using proyectoDeportiva.Areas.Identity.Data;

namespace proyectoDeportiva.Data
{
    public class ApplicationDbContext : DbContext
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
            builder.Entity <Pista>().ToTable("pista");
		}


		public DbSet<User>? Users { get; set; }

        public DbSet<Reserva>? Reservas { get; set; }
		public DbSet<Pista>? Pistas { get; set; }

    }
}
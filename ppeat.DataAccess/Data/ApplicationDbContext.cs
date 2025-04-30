using Microsoft.EntityFrameworkCore;
using ppeat.Domain.Models;

namespace ppeat.DataAccess.Data
{
    // Mit dem IdentityDbContext könnten wir die Benutzerverwaltung aus AspNetCore.Identity verwenden
    //public class ApplicationDbContext : IdentityDbContext

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Restaurant> Comments { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuring relationships
            builder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Restaurant)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.RestaurantId);

            builder.Entity<Comment>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CustomerId);

            builder.Entity<Comment>()
                .HasOne(c => c.Restaurant)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RestaurantId);

            Seed.SeedData(builder);
        }
    }
}

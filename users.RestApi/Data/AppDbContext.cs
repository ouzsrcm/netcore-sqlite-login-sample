using Microsoft.EntityFrameworkCore;
using users.RestApi.Models;

namespace users.RestApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Language> Languages { get; set; }


        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourContent> TourContents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Tablo yapılandırmaları burada yapılabilir
            modelBuilder.Entity<TourContent>()
           .HasOne(tc => tc.Tour)
           .WithMany(t => t.TourContents)
           .HasForeignKey(tc => tc.TourId);
        }
    }
}

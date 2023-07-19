using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Entities.Projections;
using Microsoft.EntityFrameworkCore;

namespace Hackamole.Quietu.Data
{
    public class QuietuDbContext : DbContext
    {
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCodeUsageCount> ProductCodeUsages { get; set; }
        public DbSet<PrincipalAttemptedProduct> PrincipalAttemptedProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=quietu;user=root;password=password");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

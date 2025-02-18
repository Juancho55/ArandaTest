using EntityFreamWorkBD.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFreamWorkBD
{
    public class ArandaTestContext : DbContext
    {
        public ArandaTestContext(DbContextOptions<ArandaTestContext> options) : base(options)
        { }

        public DbSet<Category>Caetegory { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Product>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class MarketplaceContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public MarketplaceContext(DbContextOptions _options) : base(_options)
        {
        }

        public void Clear()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            // Seed the DB
            _modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Lavender heart", Price = (decimal)9.25 },
                new Product { Id = 2, Name = "Personalised cufflinks", Price = 45 },
                new Product { Id = 3, Name = "Kids T-shirt", Price = (decimal)19.95 }
            );


        }
    }
}

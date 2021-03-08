using Microsoft.EntityFrameworkCore;
using Toystore.AspNetCore.Api.Products.Definition;

namespace Toystore.AspNetCore.Api.Products.Persistence
{
    public class ProductContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        private readonly IProductContextConfiguration _configuration;

        public ProductContext(IProductContextConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_configuration.DatabaseName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e => {
                e.ToTable("Products");
                e.Property<int>(p => p.Id)
                    .IsRequired(true)
                    .UseSqlServerIdentityColumn();
                e.Property<string>(p => p.Name)
                    .HasColumnType("NVARCHAR(50)")
                    .IsRequired(true);
                e.Property<string>(p => p.Description)
                    .HasColumnType("NVARCHAR(100)")
                    .IsRequired(false);
                e.Property<int?>(p => p.MinimumAge)
                    .IsRequired(false);
                e.Property<string>(p => p.Company)
                    .HasColumnType("NVARCHAR(50)")
                    .IsRequired(true);
                e.Property<decimal>(p => p.Price)
                    .HasColumnType("DECIMAL(6,2)")
                    .IsRequired(true);
                e.Property(p => p.Image)
                    .HasColumnType("NVARCHAR(MAX)")
                    .IsRequired(false);
                e.HasKey(p => p.Id);
            });
        }
    }
}

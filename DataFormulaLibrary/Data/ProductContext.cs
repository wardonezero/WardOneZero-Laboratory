using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.Models.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Configuration> ProductsConfigurations { get; set; }
    public DbSet<Inventory> ProductsInventories { get; set; }
    public DbSet<MetaData> ProductsMetaDatas { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> ProductsReviews { get; set; }
    public DbSet<Picture> ProductsPictures => Set<Picture>("ProductsPictures");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>("ProductsPictures");
        modelBuilder.Ignore<Picture>();
    }
}

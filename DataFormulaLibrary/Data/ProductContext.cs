using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.Models.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Models.Product.MetaData> ProductsMetaDatas { get; set; }
    public DbSet<Models.Product.Product> Products { get; set; }
    public DbSet<Models.Product.Review> Reviews { get; set; }
    public DbSet<Picture> ProductsPictures => Set<Picture>("ProductsPictures");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>("ProductsPictures");
        modelBuilder.Ignore<Picture>();
    }
}

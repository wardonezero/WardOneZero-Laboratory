using DataFormulaLibrary.Models;
using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.Models.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
{
    public const string ProductPicturesTableName = "ProductsPictures";
    public const string BrandsPicturesTableName = "BrandsPictures";

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Picture> BrandsPictures => Set<Picture>(BrandsPicturesTableName);
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    public DbSet<Configuration> ProductsConfigurations { get; set; }
    public DbSet<Inventory> ProductsInventories { get; set; }
    public DbSet<MetaData> ProductsMetaDatas { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> ProductsReviews { get; set; }
    public DbSet<Picture> ProductsPictures => Set<Picture>(ProductPicturesTableName);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>(ProductPicturesTableName);
        modelBuilder.SharedTypeEntity<Picture>(BrandsPicturesTableName);
        modelBuilder.Ignore<Picture>();
    }
}
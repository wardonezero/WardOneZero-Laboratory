using DataFormulaLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
}
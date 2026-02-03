using DataFormulaLibrary.Models;
using DataFormulaLibrary.Models.Attribute;
using DataFormulaLibrary.Models.Product.Properties;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class AttributeContext(DbContextOptions<AttributeContext> options) : DbContext(options)
{
    public DbSet<Models.Attribute.Attribute> Attributes { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Dimention> Dimentions { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
}
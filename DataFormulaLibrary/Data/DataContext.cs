using DataFormulaLibrary.Models;
using DataFormulaLibrary.Models.Attribute;
using DataFormulaLibrary.Models.Cart;
using DataFormulaLibrary.Models.Payment;
using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.Models.Product.Properties;
using DataFormulaLibrary.Models.Shared;
using DataFormulaLibrary.Models.Shared.Properties;
using DataFormulaLibrary.Models.Shipping;
using DataFormulaLibrary.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Models.Attribute.Attribute> Attributes { get; set; }
    public DbSet<AttributeValue> AttributeValues { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<WishListItem> WishListItems { get; set; }
    public DbSet<Models.Order.MetaData> OrdersMetaDatas { get; set; }
    public DbSet<Models.Order.Order> Orders { get; set; }
    public DbSet<Models.Order.OrderItem> OrderItems { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Dimention> Dimentions { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Configuration> ProductsConfigurations { get; set; }
    public DbSet<Inventory> ProductsInventories { get; set; }
    public DbSet<Models.Product.MetaData> ProductsMetaDatas { get; set; }
    public DbSet<Models.Product.Product> Products { get; set; }
    public DbSet<Models.Product.Review> ProductsReviews { get; set; }
    public DbSet<Picture> ProductsPictures => Set<Picture>("ProductsPictures");
    public DbSet<Picture> ProfilesPictures => Set<Picture>("ProfilesPictures");
    public DbSet<Picture> BrandsPictures => Set<Picture>("BrandsPictures");
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Models.Shipping.ShipmentItem> ShipmentsItems { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Models.User.MetaData> UsersMetaData { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>("ProductsPictures");
        modelBuilder.SharedTypeEntity<Picture>("ProfilesPictures");
        modelBuilder.SharedTypeEntity<Picture>("BrandsPictures");
        modelBuilder.Ignore<Picture>();
    }
}
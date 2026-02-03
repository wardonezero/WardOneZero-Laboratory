using DataFormulaLibrary.Models.Payment;
using DataFormulaLibrary.Models.Shipping;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class SalesContext(DbContextOptions<SalesContext> options) : DbContext(options)
{
    public DbSet<Models.Order.MetaData> OrdersMetaDatas { get; set; }
    public DbSet<Models.Order.Order> Orders { get; set; }
    public DbSet<Models.Order.OrderItem> OrderItems { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Models.Shipping.ShipmentItem> ShipmentsItems { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
}
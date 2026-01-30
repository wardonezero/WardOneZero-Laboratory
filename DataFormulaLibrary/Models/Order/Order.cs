using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.Order;

public class Order
{
    public int Id { get; set; } = 0;
    public int UserId { get; set; } = 0;
    public int BillingAddressId { get; set; } = 0;
    public int ShipingAddressId { get; set; } = 0;
    public byte PaymentMethodId { get; set; } = 0;
    public byte ShipingMethodId { get; set; } = 0;
    public OrderStatuses Status { get; set; } = OrderStatuses.Pending;
    public float Discount { get; set; } = 0.0f;
    public decimal Tax { get; set; } = 0.0m;
    public decimal Total { get; set; } = 0.0m;

}

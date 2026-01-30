using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.Shipping;

public class Shipment
{
    public int Id { get; set; } = 0;
    public int OrderId { get; set; } = 0;
    public string TrackingNumber { get; set; } = string.Empty;
    public float TotlWeight { get; set; } = 0.0f;
    public DateTime? Shipped { get; set; }
    public DateTime? Deliverd { get; set; }
    public ShippingStatuses ShippingStatus { get; set; } = ShippingStatuses.NotYetShipped;
    public string Comment { get; set; } = string.Empty;
}

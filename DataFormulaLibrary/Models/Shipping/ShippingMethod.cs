namespace DataFormulaLibrary.Models.Shipping;

public class ShippingMethod
{
    public int Id { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte DisplayOrder { get; set; } = 0;
}
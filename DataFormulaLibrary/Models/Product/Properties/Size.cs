namespace DataFormulaLibrary.Models.Product.Properties;

public class Size
{
    public int Id { get; set; } = 0;
    public string Value { get; set; } = string.Empty;
    public decimal Cost { get; set; } = 0.0m;
    public decimal Price { get; set; } = 0.0m;
    public float Discount { get; set; } = 0.0f;
}
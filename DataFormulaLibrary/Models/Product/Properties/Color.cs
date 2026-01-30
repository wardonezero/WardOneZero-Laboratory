namespace DataFormulaLibrary.Models.Product.Properties;

public class Color
{
    public int Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Hex { get; set; } = string.Empty;

    public decimal Cost { get; set; } = 0m;

    public decimal Price { get; set; } = 0m;

    public float Discount { get; set; } = 0f;
}
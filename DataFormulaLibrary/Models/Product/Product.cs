namespace DataFormulaLibrary.Models.Product;

public class Product
{
    public int Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public decimal Cost { get; set; } = 0m;
    public decimal Price { get; set; } = 0m;
    public float Discount { get; set; } = 0f;
}
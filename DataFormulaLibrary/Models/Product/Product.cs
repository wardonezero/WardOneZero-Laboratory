using System.ComponentModel.DataAnnotations;

namespace DataFormulaLibrary.Models.Product;

public class Product
{
    public int Id { get; set; } = 0;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string ShortDescription { get; set; } = string.Empty;

    public decimal Cost { get; set; } = 0.0m;
    public decimal Price { get; set; } = 0.0m;

    [Range(0.0f, 1.0f, ErrorMessage = "Discount must be between 0 and 1")]
    public float Discount { get; set; } = 0.0f;
}
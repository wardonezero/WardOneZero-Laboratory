namespace DataFormulaLibrary.Models.Product;

public class Configuration
{
    public int ProductId { get; set; }
    public float Weight { get; set; } = 0.0f;
    public bool IsRequestQouote { get; set; } = false;
    public bool IsRental { get; set; } = false;
    public bool Returnable { get; set; } = true;
}
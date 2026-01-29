namespace DataFormulaLibrary.Models.Product;

public class Configuration
{
    public int ProductId { get; set; }
    public bool IsRequestQouote { get; set; } = false;
    public bool IsRental { get; set; } = false;
    public bool Returnable { get; set; } = true;
}
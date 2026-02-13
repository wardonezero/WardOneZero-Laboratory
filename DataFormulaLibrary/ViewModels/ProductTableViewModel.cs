namespace DataFormulaLibrary.ViewModels;

public class ProductTableViewModel
{
    public int Id { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int InStock { get; set; }
    public bool Published { get; set; }
}

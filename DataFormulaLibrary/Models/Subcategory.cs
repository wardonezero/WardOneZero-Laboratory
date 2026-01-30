namespace DataFormulaLibrary.Models;

public class Subcategory
{
    public int Id { get; set; } = 0;
    public int CategoryId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public bool Published { get; set; } = true;
}

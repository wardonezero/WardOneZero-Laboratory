using DataFormulaLibrary.Interfaces;

namespace DataFormulaLibrary.Models;

public class Department : ICatalogItem
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link => $"/{Name.ToLower()}";
    public string Comment { get; set; } = string.Empty;
    public bool Published { get; set; } = true;

    public override string ToString() => Name;
}

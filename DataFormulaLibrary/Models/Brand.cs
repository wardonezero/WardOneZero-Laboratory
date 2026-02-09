using DataFormulaLibrary.Interfaces;

namespace DataFormulaLibrary.Models;

public class Brand : ICatalogItem
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int PictureId { get; set; } = 0;
    public bool Published { get; set; } = true;
}

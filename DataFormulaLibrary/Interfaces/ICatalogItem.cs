namespace DataFormulaLibrary.Interfaces;

public interface ICatalogItem
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Comment { get; set; }
    bool Published { get; set; }
}
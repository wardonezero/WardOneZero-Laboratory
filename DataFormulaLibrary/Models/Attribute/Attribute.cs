namespace DataFormulaLibrary.Models.Attribute;

public class Attribute
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsSelectable { get; set; } = false;
    public List<int> ValuesIds { get; set; } = [];
}

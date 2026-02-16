namespace DataFormulaLibrary.Models.Attribute;

public class AttributeValue
{
    public int Id { get; set; } = 0;
    public int AttributeId { get; set; } = 0;
    public string Value { get; set; } = string.Empty;
    public bool IsSelectable { get; set; } = false;
    public byte DisplayOrder { get; set; } = 0;
}
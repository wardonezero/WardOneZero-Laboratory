namespace DataFormulaLibrary.Models.Shared.Properties;

public class Picture
{
    public int Id { get; set; } = 0;

    public string Extention { get; set; } = string.Empty;

    public string Binary { get; set; } = string.Empty;

    public byte DisplayOrder { get; set; } = 0;
}
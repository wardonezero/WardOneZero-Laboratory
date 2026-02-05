namespace DataFormulaLibrary.Models.Shared.Properties;

public class Picture
{
    public int Id { get; set; } = 0;
    public string Extention { get; set; } = string.Empty;
    public byte[] Binary { get; set; } = [];

    public string Alt { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public byte DisplayOrder { get; set; } = 0;
}
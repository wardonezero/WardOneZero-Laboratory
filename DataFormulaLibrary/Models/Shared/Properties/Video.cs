namespace DataFormulaLibrary.Models.Shared.Properties;

public class Video
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
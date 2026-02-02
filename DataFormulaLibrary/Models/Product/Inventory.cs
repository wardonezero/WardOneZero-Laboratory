namespace DataFormulaLibrary.Models.Product;

public class Inventory
{
    public int ProductId { get; set; }
    public int InStock { get; set; } = 0;

    public List<int> ColorsIds { get; set; } = [];
    public List<int> DimentionsIds { get; set; } = [];
    public List<int> PicturesIds { get; set; } = [];
    public List<int> SizesIds { get; set; } = [];
    public List<int> AttributesValuesIds { get; set; } = [];
    public List<int> ReviewsIds { get; set; } = [];
}
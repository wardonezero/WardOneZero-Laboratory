namespace DataFormulaLibrary.Models.Shared;

public class ProductItem
{
    public int Id { get; set; } = 0;
    public int ProductId { get; set; } = 0;
    public int ColorId { get; set; } = 0;
    public int DimentionId { get; set; } = 0;
    public int SizeId { get; set; } = 0;
    public int Quantity { get; set; } = 0;
    public List<int> AttributesValuesIds { get; set; } = [];
}

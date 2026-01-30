namespace DataFormulaLibrary.Models.Order;

public class MetaData
{
    public int OrderId { get; set; } = 0;
    public List<int> OrderItemsIds { get; set; } = [];
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

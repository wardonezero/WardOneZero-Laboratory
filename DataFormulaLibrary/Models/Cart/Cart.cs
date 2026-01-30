namespace DataFormulaLibrary.Models.Cart;

public class Cart
{
    public int UserId { get; set; } = 0;
    public List<int> ProductsItemsIds { get; set; } = [];
}
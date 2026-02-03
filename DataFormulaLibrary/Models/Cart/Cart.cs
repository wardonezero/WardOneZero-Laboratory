namespace DataFormulaLibrary.Models.Cart;

public class Cart
{
    public int Id { get; set; } = 0;
    public List<int> CartItemsIds { get; set; } = [];
}
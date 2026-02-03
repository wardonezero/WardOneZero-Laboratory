namespace DataFormulaLibrary.Models.Cart;

public class WishList
{
    public int Id { get; set; } = 0;
    public List<int> ItemsIds { get; set; } = [];
}

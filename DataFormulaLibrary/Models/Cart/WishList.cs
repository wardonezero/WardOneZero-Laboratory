namespace DataFormulaLibrary.Models.Cart;

public class WishList
{
    public int UserId { get; set; } = 0;
    public List<int> ItemsIds { get; set; } = [];
}

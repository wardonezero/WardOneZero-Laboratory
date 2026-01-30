namespace DataFormulaLibrary.Models.Cart;

public class WishListItem
{
    public int Id { get; set; } = 0;
    public int ProductId { get; set; } = 0;
    public int ProductPictureId { get; set; } = 0;
    public bool IsInStock { get; set; } = true;
    public decimal Price { get; set; } = 0.0m;
    public float Discount { get; set; } = 0.0f;

}

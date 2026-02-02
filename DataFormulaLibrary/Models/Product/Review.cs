namespace DataFormulaLibrary.Models.Product;

public class Review
{
    public int Id { get; set; } = 0;
    public int ProductId { get; set; } = 0;
    public int UserId { get; set; } = 0;
    public float Stars { get; set; } = 0.0f;
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime? EditedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

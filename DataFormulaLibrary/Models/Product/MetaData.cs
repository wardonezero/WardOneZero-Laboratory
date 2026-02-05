using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.Product;

/// <summary>
/// Product's metadata
/// </summary>
public class MetaData
{
    public int Id { get; set; } = 0;
    public int DepartmentId { get; set; } = 0;
    public int BrandId { get; set; } = 0;
    public int CategoryId { get; set; } = 0;
    public int SubcategoryId { get; set; } = 0;
    public ProductStatuses Status { get; set; } = 0;

    public string MetaKeywords { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaTitle { get; set; } = string.Empty;
    public string SearchEngineFriendlyPageName { get; set; } = string.Empty;

    public DateTime? ModifiedAt { get; set; }
    public int ModifiedByUserId { get; set; } = 0;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public int CreatedByUserId { get; } = 0;
}
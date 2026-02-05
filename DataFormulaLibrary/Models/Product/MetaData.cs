using DataFormulaLibrary.Enums;
using System.ComponentModel.DataAnnotations;

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
    public ProductStatuses Status { get; set; } = ProductStatuses.Create;

    [Required]
    public string MetaKeywords { get; set; } = string.Empty;
    [Required]
    public string MetaDescription { get; set; } = string.Empty;
    [Required]
    public string MetaTitle { get; set; } = string.Empty;
    [Required]
    public string SearchEngineFriendlyPageName { get; set; } = string.Empty;

    public DateTime? ModifiedAt { get; set; }
    public int ModifiedByUserId { get; set; } = 0;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public int CreatedByUserId { get; } = 0;
}
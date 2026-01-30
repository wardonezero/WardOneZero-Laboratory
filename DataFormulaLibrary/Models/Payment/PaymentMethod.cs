namespace DataFormulaLibrary.Models.Payment;

public class PaymentMethod
{
    public int Id { get; set; } = 0;
    public int PaymentTypeId { get; set; } = 0;
    public string ProviderToker { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string LastFourDigits { get; set; } = string.Empty;
    public string ExpiryMonthYear { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;
}

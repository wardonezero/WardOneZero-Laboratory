using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.Payment;

public class PaymentTransaction
{
    public int Id { get; set; } = 0;
    public int OrderId { get; set; } = 0;
    public int PaymentMethodId { get; set; } = 0;
    public string ExternalTransactionId { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 0.0m;
    public string Currency { get; set; } = string.Empty;
    public PaymentStatuses PaymentStatus { get; set; } = PaymentStatuses.Pending;
    public TransactionTypes TransactionType { get; set; } = TransactionTypes.Sale;
    public string GatewayResponse { get; set; } = string.Empty;
    public DateTime? TransactionDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

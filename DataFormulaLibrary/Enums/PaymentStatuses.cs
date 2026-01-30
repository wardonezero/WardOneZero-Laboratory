namespace DataFormulaLibrary.Enums;

public enum PaymentStatuses
{
    Pending = 0,
    Authorized = 10,
    Paid = 20,
    PartiallyRefunded = 30,
    Refunded = 40,
    Voided = 50,
    Failed = 60
}

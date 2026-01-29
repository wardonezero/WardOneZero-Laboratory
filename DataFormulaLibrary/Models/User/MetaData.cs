namespace DataFormulaLibrary.Models.User;

/// <summary>
/// User's metadata
/// </summary>
public class MetaData
{
    public int UserId { get; set; } = 0;
    public int AddressId { get; set; } = 0;
    public int BillingAddressId { get; set; } = 0;
    public int ProfilePictureId { get; set; } = 0;
    public DateTime LastSignIn { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Token { get; set; } = string.Empty;
}
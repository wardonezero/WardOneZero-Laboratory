using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.User;

public class User
{
    public int Id { get; set; } = 0;
    public UserRoles Role { get; set; } = UserRoles.Guest;
    public UserStatuses Status { get; set; } = UserStatuses.Active;

    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public DateOnly? Birthday { get; set; }
}
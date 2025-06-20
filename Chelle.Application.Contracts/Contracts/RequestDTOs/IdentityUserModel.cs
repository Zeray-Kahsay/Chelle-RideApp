namespace Chelle.Application.Contracts.RequestDTOs;

public record IdentityUserModel
{
    public int UserId { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; }
}

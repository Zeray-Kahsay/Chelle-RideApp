namespace Chelle.Application.Contracts.ResponseDTOs;

public record UserResponse
{
  public int UserId { get; set; }
  public string PhoneNumber { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty;
  public bool IsVerified { get; set; }
  public bool CanManageRides { get; set; }
}

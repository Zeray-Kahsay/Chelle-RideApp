namespace Chelle.Application.Contracts.RequestDTOs;

public record RegisterUserRequest
{
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string PhoneNumber { get; set; } //  will be used as username
  public string Email { get; set; } = string.Empty; //  optional, only used for promotional purposes
  public required string Password { get; set; }
  public required string ConfirmPassword { get; set; }

}

namespace Chelle.Application.Contracts.RequestDTOs;

public record RegisterUserRequest
{
  public required string PhoneNumber { get; init; } //  will be used as username
  public required string FirstName { get; init; }
  public required string LastName { get; init; }
  public string Email { get; init; } = string.Empty; //  optional, only used for promotional purposes
  public required string Password { get; init; }
  public required string ConfirmPassword { get; init; }
  public required string Role { get; init; }

}

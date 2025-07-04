namespace Chelle.Application.Contracts.RequestDTOs;

public record UpdateUserRequest
{
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
}

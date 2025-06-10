namespace Chelle.Application.Contracts.ResponseDTOs;

public record RegisterUserResponse
{
  public int UserId { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Message { get; set; } = string.Empty;
  public IEnumerable<string> Errors { get; set; } = [];
}

namespace Chelle.Core.Entities;

public class User
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  //public string Role { get; set; } = "rider"; // Default role is "rider"
}

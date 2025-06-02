using Microsoft.AspNetCore.Identity;

namespace Chelle.Core.Entities;

public class AppUser : IdentityUser<int>
{
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public List<AppUserRole> UserRoles { get; set; } = [];
}

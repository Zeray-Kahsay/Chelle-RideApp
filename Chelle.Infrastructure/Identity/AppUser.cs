using Microsoft.AspNetCore.Identity;

namespace Chelle.Infrastructure.Identity;

public class AppUser : IdentityUser<int>
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public ICollection<AppUserRole> AppUserRoles { get; set; } = [];
  public bool IsVerified { get; set; }
  public bool CanManageRides { get; set; }

}

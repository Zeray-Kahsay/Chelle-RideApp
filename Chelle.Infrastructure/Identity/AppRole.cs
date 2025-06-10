using Microsoft.AspNetCore.Identity;

namespace Chelle.Infrastructure.Identity;

public class AppRole : IdentityRole<int>
{
  public ICollection<AppUserRole> AppUserRoles { get; set; } = [];
}

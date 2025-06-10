using Microsoft.AspNetCore.Identity;

namespace Chelle.Infrastructure.Identity;

public class AppUserRole : IdentityUserRole<int>
{
  public AppUser User { get; set; } = null!;
  public AppRole Role { get; set; } = null!;
  public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
}

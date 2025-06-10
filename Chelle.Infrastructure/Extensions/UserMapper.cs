using Chelle.Core.Entities;
using Chelle.Infrastructure.Identity;

namespace Chelle.Infrastructure.Extensions;

public static class UserMapper
{
  public static User ToUserDomain(this AppUser user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }
    if (string.IsNullOrWhiteSpace(user.PhoneNumber))
    {
      throw new ArgumentException("Phone number cannot be empty.", nameof(user.PhoneNumber));
    }


    return User.UserFromDb(
      user.Id,
      user.FirstName,
      user.LastName,
      user.PhoneNumber,
      user.IsVerified,
      user.CanManageRides

    );

  }

  public static AppUser ToAppUser(this User user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }
    if (string.IsNullOrWhiteSpace(user.PhoneNumber))
    {
      throw new ArgumentException("Phone number cannot be empty.", nameof(user.PhoneNumber));
    }

    return new AppUser
    {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      PhoneNumber = user.PhoneNumber,
      IsVerified = user.IsVerified,
      CanManageRides = user.CanManageRides
    };
  }
}

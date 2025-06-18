using System;
using Chelle.Application.Contracts.AuthDto;
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Core.Entities;
using Chelle.Infrastructure.Identity;

namespace Chelle.Infrastructure.Extensions;

public static class AppUserMapper
{
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

  public static TokenUserDto ToTokenUserDto(this AppUser user, IEnumerable<string> roles)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    return new TokenUserDto(
      user.Id,
      user.FirstName,
      user.LastName,
      user.PhoneNumber ?? string.Empty,
      user.Email ?? string.Empty,
      roles.FirstOrDefault() ?? string.Empty,
      user.Token ?? string.Empty,
      user.PhoneNumberConfirmed

    );
  }

  public static IdentityUserModel MapToIdentityModel(this AppUser user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    return new IdentityUserModel
    {
      FirstName = user.FirstName,
      LastName = user.LastName,
      PhoneNumber = user.PhoneNumber ?? string.Empty,
      Email = user.Email ?? string.Empty,

    };
  }
}

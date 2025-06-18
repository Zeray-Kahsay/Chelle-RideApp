using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Core.Entities;

namespace Chelle.Infrastructure.Extensions;

public static class UserMapper
{
  public static UserResponse ToUserResponse(this User user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    return new UserResponse
    {
      UserId = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email,
      IsVerified = user.IsVerified,
      CanManageRides = user.CanManageRides
    };
  }

  public static UserResponse MapToUserResponse(this IdentityUserModel user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }
    return new UserResponse
    {
      UserId = user.UserId,
      PhoneNumber = user.PhoneNumber,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email,
      Role = user.Role ?? string.Empty,
      Token = user.Token ?? string.Empty,

    };
  }
}

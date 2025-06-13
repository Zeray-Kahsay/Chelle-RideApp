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
}

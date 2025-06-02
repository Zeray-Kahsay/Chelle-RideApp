using System;
using Chelle.Core.Entities;

namespace Chelle.Core.Interfaces;

public interface IUserRepository
{
  Task<AppUser> GetUserByIdAsync(Guid userId);
  Task<IEnumerable<AppUser>> GetAllUsersAsync();
  Task<AppUser> AddUserAsync(AppUser user);
  Task<AppUser> UpdateUserAsync(AppUser user);

}

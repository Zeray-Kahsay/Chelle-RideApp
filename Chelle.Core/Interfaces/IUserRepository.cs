using System;
using Chelle.Core.Entities;

namespace Chelle.Core.Interfaces;

public interface IUserRepository
{
  Task<User> GetUserByIdAsync(Guid userId);
  Task<IEnumerable<User>> GetAllUsersAsync();
  Task<User> AddUserAsync(User user);
  Task<User> UpdateUserAsync(User user);

}

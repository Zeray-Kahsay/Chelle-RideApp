using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Core.Entities;

public interface IUserRepository
{
  Task<User> GetUserByPhoneAsync(string phoneNumber);
  Task<User> GetUserByIdAsync(int id);
  Task<IEnumerable<User>> GetAllUsersAsync();
  Task<User> AddUserAsync(User user);
  Task<User> UpdateUserAsync(User user);
  Task<bool> DeleteUserAsync(string phoneNumber);

}

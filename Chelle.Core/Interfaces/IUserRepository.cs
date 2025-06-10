using Chelle.Core.Entities;

public interface IUserRepository
{
  Task<User> GetUserByPhoneAsync(string phoneNumber);
  Task<IEnumerable<User>> GetAllUsersAsync();
  Task<User> AddUserAsync(User user);
  Task<User> UpdateUserAsync(User user);

}

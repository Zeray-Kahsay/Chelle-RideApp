using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Core.Entities;
using Chelle.Infrastructure.Data;
using Chelle.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;
  public UserRepository(AppDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }
  public async Task<User> GetUserByPhoneAsync(string phoneNumber)
  {
    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
      throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
    }
    var user = await _context.Users
                             .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber)
                             ?? throw new KeyNotFoundException($"User with phone number {phoneNumber} not found.");
    return user.ToUserDomain();

  }
  public async Task<User> GetUserByIdAsync(int id)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id)
                                    ?? throw new KeyNotFoundException($"User with user id {id} not found");
    return user.ToUserDomain();
  }
  public async Task<IEnumerable<User>> GetAllUsersAsync()
  {
    var users = await _context.Users.ToListAsync();

    if (users.Count > 0)
    {
      return users.Select(u => u.ToUserDomain());
    }
    else
    {
      throw new KeyNotFoundException("No users found.");
    }
  }
  public async Task<User> AddUserAsync(User user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    _context.Users.Add(user.ToAppUser());
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User> UpdateUserAsync(User user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    var existingUser = await _context.Users.FindAsync(user.Id) ?? throw new KeyNotFoundException($"User with ID {user.Id} not found.");
    _context.Entry(existingUser).CurrentValues.SetValues(user);
    await _context.SaveChangesAsync();
    return existingUser.ToUserDomain();
  }

  public Task<bool> DeleteUserAsync(string phoneNumber)
  {

    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
      throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
    }
    return _context.Users
                   .Where(u => u.PhoneNumber == phoneNumber)
                   .Select(u => new { u.Id, u.PhoneNumber })
                   .ExecuteDeleteAsync()
                   .ContinueWith(task =>
                   {
                     if (task.Result > 0)
                     {
                       return true;
                     }
                     else
                     {
                       throw new KeyNotFoundException($"User with phone number {phoneNumber} not found.");
                     }
                   });
  }
}

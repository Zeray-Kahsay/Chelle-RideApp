using Chelle.Core.Entities;
using Chelle.Core.Interfaces;
using Chelle.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  /// <summary>
  /// Represents the application's database context used for accessing and managing entities within the database.
  /// </summary>
  private readonly AppDbContext _context;
  public UserRepository(AppDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }
  public async Task<User> GetUserByIdAsync(Guid userId)
  {
    if (userId == Guid.Empty)
    {
      throw new ArgumentException("User ID cannot be empty.", nameof(userId));
    }

    return await _context.Users.FindAsync(userId)
           ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
  }
  public async Task<IEnumerable<User>> GetAllUsersAsync()
  {
    return await _context.Users.ToListAsync();
  }
  public async Task<User> AddUserAsync(User user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "User cannot be null.");
    }

    _context.Users.Add(user);
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
    return existingUser;
  }
}

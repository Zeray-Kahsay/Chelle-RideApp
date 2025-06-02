using Chelle.Core.Entities;
using Chelle.Core.Interfaces;
using Chelle.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;
  public UserRepository(AppDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }
  public async Task<AppUser> GetUserByIdAsync(Guid userId)
  {
    if (userId == Guid.Empty)
    {
      throw new ArgumentException("AppUser ID cannot be empty.", nameof(userId));
    }

    return await _context.Users.FindAsync(userId)
           ?? throw new KeyNotFoundException($"AppUser with ID {userId} not found.");
  }
  public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
  {
    return await _context.Users.ToListAsync();
  }
  public async Task<AppUser> AddUserAsync(AppUser user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "AppUser cannot be null.");
    }

    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<AppUser> UpdateUserAsync(AppUser user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "AppUser cannot be null.");
    }

    var existingUser = await _context.Users.FindAsync(user.Id) ?? throw new KeyNotFoundException($"AppUser with ID {user.Id} not found.");
    _context.Entry(existingUser).CurrentValues.SetValues(user);
    await _context.SaveChangesAsync();
    return existingUser;
  }
}

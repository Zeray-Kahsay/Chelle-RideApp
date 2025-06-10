using Chelle.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

  public DbSet<AppUser> Users { get; set; }



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Configure your entities here
    base.OnModelCreating(modelBuilder);
  }

}

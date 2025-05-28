using System;
using Chelle.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

  public DbSet<User> Users { get; set; }



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Configure your entities here
    base.OnModelCreating(modelBuilder);
  }

  // Define DbSets for your entities
  // public DbSet<User> Users { get; set; }
}

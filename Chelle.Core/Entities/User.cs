using Microsoft.AspNetCore.Identity;

namespace Chelle.Core.Entities;

public record User
{
  public int Id { get; private set; }
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public string PhoneNumber { get; private set; }
  public string Email { get; set; } = string.Empty;

  public bool IsVerified { get; private set; }
  public bool CanManageRides { get; private set; }

  // Private constructor: enforce usage of factory methods
  private User(int id, string firstName, string lastName, string phoneNumber)
  {
    Id = id;
    FirstName = firstName;
    LastName = lastName;
    PhoneNumber = phoneNumber;
    IsVerified = false;
    CanManageRides = false;
  }

  // Factory method for user creation
  public static User CreateNewUser(int id, string firstName, string lastName, string phoneNumber) =>
     new(id, firstName, lastName, phoneNumber);


  // Factory method for internal or mapping use
  public static User UserFromDb(int id, string firstName, string lastName, string phoneNumber, bool isVerified, bool canManageRides) =>
    new(id, firstName, lastName, phoneNumber)
    {
      IsVerified = isVerified,
      CanManageRides = canManageRides
    };

  // Domain behavior methods
  public void VerifyPhone()
  {
    if (!IsVerified)
    {
      IsVerified = true;
    }
    else
    {
      throw new InvalidOperationException("User is already verified.");
    }
  }
  public void PromoteToDispatcher()
  {
    if (IsVerified)
    {
      CanManageRides = true;
    }
    else
    {
      throw new InvalidOperationException("User must be verified before being promoted to dispatcher.");
    }
  }
  public void DemoteFromDispatcher()
  {
    if (CanManageRides)
    {
      CanManageRides = false;
    }
    else
    {
      throw new InvalidOperationException("User is not a dispatcher.");
    }
  }
}

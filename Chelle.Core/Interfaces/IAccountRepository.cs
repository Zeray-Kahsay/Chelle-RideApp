using Chelle.Core.Entities;

namespace Chelle.Core.Interfaces;

public interface IAccountRepository
{
  Task<User> RegisterAsync(string phoneNumber, string password, string firstName, string lastName);
  Task<User> LoginAsync(string phoneNumber, string password);
  Task<bool> VerifyPhoneAsync(string phoneNumber, string verificationCode);
  Task<bool> ResetPasswordAsync(string phoneNumber, string newPassword);
}

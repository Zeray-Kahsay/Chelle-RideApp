
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;

namespace Chelle.Application.Services;

public interface IAccountService
{
  Task<Result<UserResponse>> RegisterUserAsync(RegisterUserRequest request);
  Task<Result<UserResponse>> LoginUserAsync(LoginUserRequest request);
  Task<Result<bool>> VerifyPhoneAsync(string phoneNumber, string verificationCode);
  Task<Result<bool>> ResetPasswordAsync(ResetPasswordRequest request);
  Task<Result<IList<string>>> GetRolesAsync(string phoneNumber);
  Task<Result<bool>> AddToRoleAsync(string phoneNumber, string roleName);
  Task<Result<bool>> CheckPasswordAsync(string phoneNumber, string password);


}

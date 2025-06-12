
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;

namespace Chelle.Application.Interfaces;

public interface IAccountSerivice
{
  Task<Result<UserResponse>> RegisterAsync(RegisterUserRequest request);
  Task<Result<UserResponse>> LoginAsync(LoginUserRequest request);
  Task<Result<bool>> VerifyPhoneAsync(string phoneNumber, string verificationCode);
  Task<Result<bool>> ResetPasswordAsync(ResetPasswordRequest request);

}

using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Core.Common;

namespace Chelle.Application.Services;

public interface IAccountService
{
  Task<Result<UserResponse>> RegisterUserAsync(RegisterUserRequest request);
  Task<Result<UserResponse>> LoginUserAsync(LoginUserRequest request);
  Task<Result<bool>> ResetPasswordAsync(ResetPasswordRequest request);



}

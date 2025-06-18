using System;
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Core.Common;

namespace Chelle.Application.Services;

public interface IUserService
{
    Task<Core.Common.Result<UserResponse>> GetUserByPhoneAsync(string phoneNumber);
    Task<Result<IEnumerable<UserResponse>>> GetAllUsersAsync();
    Task<Result<UserResponse>> GetUserByIdAsync(int userId);
    Task<Result<bool>> DeleteUserAsync(string phoneNumber);
    Task<Result<UserResponse>> UpdateUserAsync(UpdateUserRequest request);
}

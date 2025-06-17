using System;
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;

namespace Chelle.Application.Services;

public interface IUserService
{
    Task<Result<UserResponse>> GetUserByPhoneAsync(string phoneNumber);
    Task<Result<IEnumerable<UserResponse>>> GetAllUsersAsync();
    Task<Result<UserResponse>> GetUserByIdAsync(int userId);
    Task<Result<bool>> DeleteUserAsync(string phoneNumber);
    Task<Result<UserResponse>> UpdateUserAsync(UpdateUserRequest request);
}


using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;

namespace Chelle.Application.Interfaces;

public interface IUserservice
{
  Task<Result<UserResponse>> GetUserByPhoneAsync(string phoneNumber);
  Task<Result<UserResponse>> GetUserByIdAsync(int userId);
  Task<Result<IEnumerable<UserResponse>>> GetAllUsersAsync();
  Task<Result<UserResponse>> UpdateUserAsync(UpdateUserRequest request);
  Task<Result<bool>> DeleteUserAsync(string phoneNumber);
}


using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Application.Interfaces;

namespace Chelle.Application.Services;

public class UserService : IUserservice
{
  private readonly IUserRepository _repo;

  public UserService(IUserRepository repo)
  {
    _repo = repo ?? throw new ArgumentNullException(nameof(repo));
  }
  public async Task<Result<UserResponse>> GetUserByPhoneAsync(string phoneNumber)
  {
    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
      throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
    }

    var user = await _repo.GetUserByPhoneAsync(phoneNumber);
    return user is null ? Result<UserResponse>.Failure("User not found")
                        : Result<UserResponse>.Success(user.ToUserResponse()); // Assuming ToUserResponse is an extension method that maps User to UserResponse

  }

  public Task<Result<IEnumerable<UserResponse>>> GetAllUsersAsync()
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserResponse>> GetUserByIdAsync(int userId)
  {
    throw new NotImplementedException();
  }

  public Task<Result<bool>> DeleteUserAsync(string phoneNumber)
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserResponse>> UpdateUserAsync(UpdateUserRequest request)
  {
    throw new NotImplementedException();
  }


}

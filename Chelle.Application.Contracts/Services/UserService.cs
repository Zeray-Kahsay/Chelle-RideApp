using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Infrastructure.Extensions;


namespace Chelle.Application.Services;

public class UserService : IUserService
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
                        : Result<UserResponse>.Success(user.ToUserResponse());

  }

  public async Task<Result<IEnumerable<UserResponse>>> GetAllUsersAsync()
  {
    var users = await _repo.GetAllUsersAsync();
    if (users is null || !users.Any())
    {
      return Result<IEnumerable<UserResponse>>.Failure("No users found.");
    }

    var userResponses = users.Select(u => u.ToUserResponse());
    return Result<IEnumerable<UserResponse>>.Success(userResponses);
  }

  public async Task<Result<UserResponse>> GetUserByIdAsync(int userId)
  {
    if (userId <= 0)
    {
      throw new ArgumentOutOfRangeException(nameof(userId), "User ID must be greater than zero.");
    }

    var user = await _repo.GetUserByIdAsync(userId);
    return user is null ? Result<UserResponse>.Failure($"User with ID {userId} not found.")
                        : Result<UserResponse>.Success(user.ToUserResponse());
  }

  public async Task<Result<bool>> DeleteUserAsync(string phoneNumber)
  {
    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
      throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
    }

    var result = await _repo.DeleteUserAsync(phoneNumber);
    return result ? Result<bool>.Success(true)
                  : Result<bool>.Failure($"User with phone number {phoneNumber} not found.");
  }

  public async Task<Result<UserResponse>> UpdateUserAsync(UpdateUserRequest request)
  {
    // null check early exit
    if (request is null)
      return Result<UserResponse>.Failure("Update request cannot be null.");
    // Validate request properties
    if (string.IsNullOrWhiteSpace(request.PhoneNumber))
      return Result<UserResponse>.Failure("Phone number cannot be null or empty.");

    // Retrieve user by phone number
    var user = await _repo.GetUserByPhoneAsync(request.PhoneNumber);
    if (user is null)
    {
      return Result<UserResponse>.Failure($"User with phone number {request.PhoneNumber} not found.");
    }

    // Update user using the domain logic 
    try
    {
      user.UpdateFromRequest(request.FirstName, request.LastName, request.PhoneNumber, request.Email);
    }
    catch (Exception ex)
    {
      return Result<UserResponse>.Failure($"Failed to update user: {ex.Message}");
    }

    // Persist the updated user

    var updatedUser = await _repo.UpdateUserAsync(user);

    // Map the updated user to a response DTO

    return updatedUser is null ? Result<UserResponse>.Failure("Failed to update user.")
                               : Result<UserResponse>.Success(updatedUser.ToUserResponse());





  }


}


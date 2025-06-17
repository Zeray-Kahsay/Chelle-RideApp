using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Application.Interfaces;

namespace Chelle.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }


    public async Task<Result<UserResponse>> RegisterUserAsync(RegisterUserRequest request)
    {
        var existingUser = await _accountRepository.FindUserByPhoneAsync(request.PhoneNumber);
        if (existingUser != null)
        {
            return Result<UserResponse>.Failure("User already exists.");
        }

        var identityUserModel = new IdentityUserModel
        {
            PhoneNumber = request.PhoneNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = request.Role // Assuming Role is optional
        };
        var identityResult = await _accountRepository.CreateUserAsync(identityUserModel, request.Password);
        if (!identityResult.Succeeded)
        {
            return Result<UserResponse>.Failure("User registration failed: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
        }


        // var userResponse = new UserResponse
        // {
        //     PhoneNumber = identityUserModel.PhoneNumber,
        //     FirstName = identityUserModel.FirstName,
        //     LastName = identityUserModel.LastName,
        //     Email = identityUserModel.Email,
        //     Role = identityUserModel.Role
        // };

        var userResponse = MapToUserResponse(identityUserModel);
        //userResponse.IsVerified = false; // Default to false, can be updated later
        //userResponse.CanManageRides = false; // Default to false, can be updated later
        //userResponse.UserId = 0; // Assuming UserId is not set during registration, can be updated later
        return Result<UserResponse>.Success(userResponse);
    }


    public async Task<Result<UserResponse>> LoginUserAsync(LoginUserRequest request)
    {
        var user = await _accountRepository.FindUserByPhoneAsync(request.PhoneNumber);
        if (user == null)
        {
            return Result<UserResponse>.Failure("User not found.");
        }

        var isPasswordValid = await _accountRepository.CheckPasswordAsync(request.PhoneNumber, request.Password);
        if (!isPasswordValid)
        {
            return Result<UserResponse>.Failure("Invalid password.");
        }

        // check if the user is verified
        if (!user.PhoneNumberConfirmed)
        {
            return Result<UserResponse>.Failure("User phone number is not verified.");
        }


        var userResponse = MapToUserResponse(user);
        //userResponse.IsVerified = true; // Assuming user is verified upon login
        //userResponse.CanManageRides = true; // Assuming user can manage rides upon login
        //userResponse.UserId = 0; // Assuming UserId is not set during login, can be updated later

        return Result<UserResponse>.Success(userResponse);
    }


    public Task<Result<bool>> AddToRoleAsync(string phoneNumber, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> CheckPasswordAsync(string phoneNumber, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IList<string>>> GetRolesAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }


    public Task<Result<bool>> ResetPasswordAsync(ResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }


    public Task<Result<bool>> VerifyPhoneAsync(string phoneNumber, string verificationCode)
    {
        throw new NotImplementedException();
    }

    private static UserResponse MapToUserResponse(IdentityUserModel user)
    {
        return new UserResponse
        {
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role ?? string.Empty, // Handle null role

        };
    }
}



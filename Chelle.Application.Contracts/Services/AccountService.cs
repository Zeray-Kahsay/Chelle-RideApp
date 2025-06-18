using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Contracts.ResponseDTOs;
using Chelle.Application.Interfaces;
using Chelle.Core.Common;
using Chelle.Infrastructure.Extensions;

namespace Chelle.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITokenService _tokenService;
    public AccountService(IAccountRepository accountRepository, ITokenService tokenService)
    {
        _accountRepository = accountRepository;
        _tokenService = tokenService;
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

        var userResponse = identityUserModel.MapToUserResponse();

        return Result<UserResponse>.Success(userResponse);
    }


    public async Task<Result<UserResponse>> LoginUserAsync(LoginUserRequest request)
    {
        var user = await _accountRepository.FindUserByPhoneAsync(request.PhoneNumber);
        if (user == null)
        {
            return Result<UserResponse>.Failure("User not found.");
        }

        // check if the user is verified
        if (!user.PhoneNumberConfirmed)
        {
            return Result<UserResponse>.Failure("User phone number is not verified.");
        }

        var isPasswordValid = await _accountRepository.CheckUserPasswordAsync(request.PhoneNumber, request.Password);
        if (!isPasswordValid)
        {
            return Result<UserResponse>.Failure("Invalid password.");
        }

        // Generate JWT token
        var token = await _tokenService.GenerateTokenAsync(user);
        if (string.IsNullOrEmpty(token))
        {
            return Result<UserResponse>.Failure("Failed to generate token.");
        }
        user.Token = token;

        var userResponse = user.MapToUserResponse();

        return Result<UserResponse>.Success(userResponse);
    }

    public async Task<Result<bool>> ResetPasswordAsync(ResetPasswordRequest request)
    {
        var user = await _accountRepository.FindUserByPhoneAsync(request.PhoneNumber);
        if (user is null) return Result<bool>.Failure("User not found.");

        // check if the usrer is verified
        if (!user.PhoneNumberConfirmed)
        {
            return Result<bool>.Failure("User phone number is not verified.");
        }

        // Check for code verification
        var isCodeValid = await _accountRepository.VerifyPhoneAsync(request.PhoneNumber, request.VerificationCode);
        if (!isCodeValid)
        {
            return Result<bool>.Failure("Invalid verification code.");
        }

        // Reset the password
        var resetSuccess = await _accountRepository.ResetPasswordAsync(request.PhoneNumber, request.NewPassword);

        return resetSuccess
            ? Result<bool>.Success(true)
            : Result<bool>.Failure("Password reset failed: ");


    }
}



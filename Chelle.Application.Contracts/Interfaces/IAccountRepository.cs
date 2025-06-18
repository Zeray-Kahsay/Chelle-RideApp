using System;
using Chelle.Application.Contracts.RequestDTOs;
using Microsoft.AspNetCore.Identity;

namespace Chelle.Application.Interfaces;

public interface IAccountRepository
{
    Task<IdentityResult> CreateUserAsync(IdentityUserModel user, string password);
    Task<IdentityUserModel?> FindUserByPhoneAsync(string phoneNumber);
    Task<IList<string>> GetRolesAsync(string phoneNumber);
    Task<bool> CheckUserPasswordAsync(string phoneNumber, string password);
    Task<bool> VerifyPhoneAsync(string phoneNumber, string verificationCode);
    Task<bool> ResetPasswordAsync(string phoneNumber, string newPassword);
}


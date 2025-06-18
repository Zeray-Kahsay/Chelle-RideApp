using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Interfaces;
using Chelle.Infrastructure.Extensions;
using Chelle.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chelle.Infrastructure.Repositories;

public class AccountRepositoty : IAccountRepository
{
    private readonly UserManager<AppUser> _userManager;
    public AccountRepositoty(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IdentityResult> CreateUserAsync(IdentityUserModel user, string password)
    {
        var appUser = new AppUser
        {
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.PhoneNumber, // PhoneNumber is used as username          
        };

        var result = await _userManager.CreateAsync(appUser, password);
        if (result.Succeeded)
        {
            // Assign the role to the user
            if (!string.IsNullOrEmpty(user.Role))
            {
                await _userManager.AddToRoleAsync(appUser, user.Role);
            }
        }
        return result;
    }
    public async Task<IdentityUserModel?> FindUserByPhoneAsync(string phoneNumber)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        return user is null ? null : user.MapToIdentityModel();

    }
    public async Task<bool> CheckUserPasswordAsync(string phoneNumber, string password)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        return user is not null && await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetRolesAsync(string phoneNumber)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        return user is null ? [] : await _userManager.GetRolesAsync(user);
    }

    public async Task<bool> ResetPasswordAsync(string phoneNumber, string newPassword)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user is null)
        {
            return false;
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);


        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }

    public async Task<bool> VerifyPhoneAsync(string phoneNumber, string verificationCode)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user is null)
        {
            return false;
        }

        var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, verificationCode, phoneNumber);
        if (result)
        {
            user.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(user);
        }
        return result;
    }


}

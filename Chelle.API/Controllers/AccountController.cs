using Chelle.API.Extensions;
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Controllers;

[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest request)
    {
        var result = await _accountService.RegisterUserAsync(request);
        return result.ToActionBadRequestResult();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserRequest request)
    {
        var result = await _accountService.LoginUserAsync(request);
        return result.ToActionUnAuthorizedResult();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
    {
        var result = await _accountService.ResetPasswordAsync(request);
        return result.ToActionBadRequestResult();
    }
}

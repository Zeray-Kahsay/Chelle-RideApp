using Chelle.Application.Services;
using Chelle.Infrastructure.Extensions;
using Chelle.Infrastructure.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  private readonly ITokenService _tokenService;

  public AuthController(IUserRepository userRepository, ITokenService tokenService)
  {
    _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
  }

  [HttpPost("google-token-login")]
  public async Task<IActionResult> LoginWithGoogle([FromBody] string token)
  {
    // Verify Google token
    var payload = await GoogleJsonWebSignature.ValidateAsync(token);
    if (payload == null)
    {
      return Unauthorized("Invalid Google token.");
    }

    //Lookup or create user
    var appUser = new AppUser();
    var user = (await _userRepository.GetAllUsersAsync())
      .FirstOrDefault(u => u.Email == payload.Email);
    if (user == null)
    {
      appUser = new AppUser
      {
        FirstName = payload.GivenName,
        LastName = payload.FamilyName,
        Email = payload.Email,


      };
      user = await _userRepository.AddUserAsync(appUser.ToUserDomain());
    }

    //TODO LATER

    // Generate JWT token
    //var jwtToken = _tokenService.GenerateTokenAsync(appUser.ToTokenUserDto(user.Roles));
    return Ok(new
    {
      //Token = jwtToken,
      AppUser = new
      {
        user.Id,
        user.FirstName,
        user.LastName,
        user.Email,
      }
    });

  }
}

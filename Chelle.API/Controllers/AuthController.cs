using Chelle.API.Services;
using Chelle.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Controllers;

public class AuthController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  private readonly TokenService _tokenService;

  public AuthController(IUserRepository userRepository, TokenService tokenService)
  {
    _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
  }
}

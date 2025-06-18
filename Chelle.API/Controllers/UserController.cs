using Chelle.API.Extensions;
using Chelle.Application.Contracts.RequestDTOs;
using Chelle.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService ?? throw new ArgumentNullException(nameof(userService));
  }

  [HttpGet("{phoneNumber}")]
  public async Task<IActionResult> GetUserByPhone(string phoneNumber)
  {
    var result = await _userService.GetUserByPhoneAsync(phoneNumber);
    return result.ToActionBadRequestResult();
  }


  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    var result = await _userService.GetUserByIdAsync(id);
    return result.ToActionNotFoundResult();
  }

  [HttpGet]
  public async Task<IActionResult> GetAllUsers()
  {
    var result = await _userService.GetAllUsersAsync();
    return result.ToActionBadRequestResult();
  }

  [HttpPut]
  public async Task<IActionResult> UpdateUser(UpdateUserRequest user)
  {
    var result = await _userService.UpdateUserAsync(user);
    return result.ToActionBadRequestResult();
  }
}

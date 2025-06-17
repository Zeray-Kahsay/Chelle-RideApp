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
    return result.ToActionResult();
  }


  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    try
    {
      var user = await _userService.GetUserByIdAsync(id);
      return Ok(user);
    }
    catch (KeyNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpGet]
  public async Task<IActionResult> GetAllUsers()
  {
    var users = await _userService.GetAllUsersAsync();
    return Ok(users);
  }

  // [HttpPost]
  // public async Task<IActionResult> AddUser([FromBody] AppUser user)
  // {
  //   if (user == null)
  //   {
  //     return BadRequest("AppUser cannot be null.");
  //   }

  //   var createdUser = await _userService(user.ToUserDomain());
  //   return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
  // }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest user)
  {
    if (user == null || user.Id != id)
    {
      return BadRequest("Invalid user data.");
    }

    try
    {
      var updatedUser = await _userService.UpdateUserAsync(user);
      return Ok(updatedUser);
    }
    catch (KeyNotFoundException)
    {
      return NotFound();
    }
  }
}

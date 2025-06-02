using Chelle.Core.Entities;
using Chelle.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserRepository _userRepository;

  public UserController(IUserRepository userRepository)
  {
    _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(Guid id)
  {
    try
    {
      var user = await _userRepository.GetUserByIdAsync(id);
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
    var users = await _userRepository.GetAllUsersAsync();
    return Ok(users);
  }

  [HttpPost]
  public async Task<IActionResult> AddUser([FromBody] AppUser user)
  {
    if (user == null)
    {
      return BadRequest("AppUser cannot be null.");
    }

    var createdUser = await _userRepository.AddUserAsync(user);
    return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(Guid id, [FromBody] AppUser user)
  {
    // if (user == null || user.Id != id)
    // {
    //   return BadRequest("Invalid user data.");
    // }

    try
    {
      var updatedUser = await _userRepository.UpdateUserAsync(user);
      return Ok(updatedUser);
    }
    catch (KeyNotFoundException)
    {
      return NotFound();
    }
  }
}

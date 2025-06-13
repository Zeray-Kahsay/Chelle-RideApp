using Chelle.Infrastructure.Extensions;
using Chelle.Infrastructure.Identity;
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
  public async Task<IActionResult> GetUserById(int id)
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

    var createdUser = await _userRepository.AddUserAsync(user.ToUserDomain());
    return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(int id, [FromBody] AppUser user)
  {
    if (user == null || user.Id != id)
    {
      return BadRequest("Invalid user data.");
    }

    try
    {
      var updatedUser = await _userRepository.UpdateUserAsync(user.ToUserDomain());
      return Ok(updatedUser);
    }
    catch (KeyNotFoundException)
    {
      return NotFound();
    }
  }
}

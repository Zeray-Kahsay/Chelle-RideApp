using System;

namespace Chelle.Application.Contracts.RequestDTOs;

public record LoginUserRequest
{
  public required string PhoneNumber { get; set; }
  public required string Password { get; set; }
  public bool RememberMe { get; set; } = false;
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chelle.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Chelle.API.Services;

public class TokenService
{
  private readonly IConfiguration _configuration;
  public TokenService(IConfiguration configuration) => _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
  public string GenerateToken(AppUser user)
  {
    if (user == null)
    {
      throw new ArgumentNullException(nameof(user), "AppUser cannot be null.");
    }

    var claims = new List<Claim>()
    {
      new(JwtRegisteredClaimNames.Name, user.FirstName),
      new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
      new(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber ?? string.Empty),
    };

    var secretKey = _configuration["JwtSettings:SecretKey"];
    if (string.IsNullOrEmpty(secretKey))
    {
      throw new InvalidOperationException("JWT Secret Key is not configured.");
    }
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var expires = DateTime.UtcNow.AddMinutes(30); // Token expiration time

    var token = new JwtSecurityToken(
      issuer: _configuration["JwtSettings:Issuer"],
      audience: _configuration["JwtSettings:Audience"],
      claims: claims,
      expires: expires,
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}

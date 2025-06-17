using Chelle.Application.Contracts.AuthDto;

namespace Chelle.Application.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(TokenUserDto user);
}

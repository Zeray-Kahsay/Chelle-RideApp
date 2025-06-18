using Chelle.Application.Contracts.AuthDto;
using Chelle.Application.Contracts.RequestDTOs;

namespace Chelle.Application.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(IdentityUserModel user);
}

namespace Chelle.Application.Contracts.AuthDto;

public record TokenUserDto(int Id,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string Email,
    string Role,
    string Token,
    bool PhoneNumberConfirmed);



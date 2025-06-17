namespace Chelle.Application.Contracts.AuthDto;

public record TokenUserDto(int Id, string FirstName, string LastName, string PhoneNumber, string Role, string Email);


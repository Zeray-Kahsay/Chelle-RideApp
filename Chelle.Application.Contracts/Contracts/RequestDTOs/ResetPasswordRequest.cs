
namespace Chelle.Application.Contracts.RequestDTOs;

public record ResetPasswordRequest
{

  public string PhoneNumber { get; set; } = string.Empty;


  public string NewPassword { get; set; } = string.Empty;


  public string VerificationCode { get; set; } = string.Empty;
}

using System.Runtime.CompilerServices;
using Chelle.Core.Services;
using Resend;

namespace Chelle.Infrastructure.Repositories;

public class ResendEmailSender : IResendEmailSender
{
  private readonly ResendClient _client;

  public ResendEmailSender(ResendClient client)
  {
    _client = client ?? throw new ArgumentNullException(nameof(client), "ResendClient cannot be null.");
  }

  public async Task SendEmailAsync(string to, string subject, string htmlBody)
  {
    await _client.EmailSendAsync(new EmailMessage
    {
      From = "kahsayzeray@gmail.com",
      To = to,
      Subject = subject,
      HtmlBody = htmlBody
    });
  }


}

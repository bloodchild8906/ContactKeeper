using ContactKeeper.Application.Common.Models;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}

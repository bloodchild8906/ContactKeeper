using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.Cities.EventHandler;

public class CityActivatedEventHandler : INotificationHandler<DomainEventNotification<CityActivatedEvent>>
{
    private readonly ILogger<CityActivatedEventHandler> _logger;
    private readonly IEmailService _emailService;

    public CityActivatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    public async Task Handle(DomainEventNotification<CityActivatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.City != null)
        {
            await _emailService.SendAsync(new EmailRequest
            {
                Subject = domainEvent.City.Name + " is activated.",
                Body = "City is activated successfully.",
                FromDisplayName = "Clean Architecture",
                FromMail = "test@test.com",
                ToMail = new List<string> { "to@test.com" }
            });
        }
    }
}

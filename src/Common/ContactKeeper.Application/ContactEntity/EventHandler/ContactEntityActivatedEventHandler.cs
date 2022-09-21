using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactEntity.EventHandler;

public class ContactEntityActivatedEventHandler : INotificationHandler<DomainEventNotification<ContactEntityCreatedEvent>>
{
    private readonly ILogger<ContactEntityActivatedEventHandler> _logger;
    
    public ContactEntityActivatedEventHandler(ILogger<ContactEntityActivatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(DomainEventNotification<ContactEntityCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
    }
}

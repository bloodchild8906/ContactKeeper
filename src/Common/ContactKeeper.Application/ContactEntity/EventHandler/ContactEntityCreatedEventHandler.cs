using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactEntity.EventHandler;

public class ContactEntityCreatedEventHandler : INotificationHandler<DomainEventNotification<ContactEntityCreatedEvent>>
{
    private readonly ILogger<ContactEntityActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public ContactEntityCreatedEventHandler(ILogger<ContactEntityActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<ContactEntityCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.ContactEntity != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

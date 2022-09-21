using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactPeople.EventHandler;

public class ContactPersonCreatedEventHandler : INotificationHandler<DomainEventNotification<ContactPersonCreatedEvent>>
{
    private readonly ILogger<ContactPersonActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public ContactPersonCreatedEventHandler(ILogger<ContactPersonActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<ContactPersonCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.ContactPerson != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

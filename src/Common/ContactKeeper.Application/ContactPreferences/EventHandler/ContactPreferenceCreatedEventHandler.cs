using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactPreferences.EventHandler;

public class ContactPreferenceCreatedEventHandler : INotificationHandler<DomainEventNotification<ContactPreferenceCreatedEvent>>
{
    private readonly ILogger<ContactPreferenceActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public ContactPreferenceCreatedEventHandler(ILogger<ContactPreferenceActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<ContactPreferenceCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.ContactPreference != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

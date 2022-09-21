using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactPreferences.EventHandler;

public class ContactPreferenceActivatedEventHandler : INotificationHandler<DomainEventNotification<ContactPreferenceCreatedEvent>>
{
    private readonly ILogger<ContactPreferenceActivatedEventHandler> _logger;
    private readonly IDomainEventService _eventService;

    public ContactPreferenceActivatedEventHandler(ILogger<ContactPreferenceActivatedEventHandler> logger, IDomainEventService eventservice)
    {
        _logger = logger;
        _eventService = eventservice;
    }

    public async Task Handle(DomainEventNotification<ContactPreferenceCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
    }
}

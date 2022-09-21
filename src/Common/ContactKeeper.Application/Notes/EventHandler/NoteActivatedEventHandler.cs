using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.Notes.EventHandler;

public class NoteActivatedEventHandler : INotificationHandler<DomainEventNotification<NoteCreatedEvent>>
{
    private readonly ILogger<NoteActivatedEventHandler> _logger;
    private readonly IDomainEventService _eventService;

    public NoteActivatedEventHandler(ILogger<NoteActivatedEventHandler> logger, IDomainEventService eventservice)
    {
        _logger = logger;
        _eventService = eventservice;
    }

    public async Task Handle(DomainEventNotification<NoteCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
    }
}

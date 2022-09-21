using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.Notes.EventHandler;

public class NoteCreatedEventHandler : INotificationHandler<DomainEventNotification<NoteCreatedEvent>>
{
    private readonly ILogger<NoteActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public NoteCreatedEventHandler(ILogger<NoteActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<NoteCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.Note != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

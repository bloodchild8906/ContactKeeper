using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.Users.EventHandler;

public class UserActivatedEventHandler : INotificationHandler<DomainEventNotification<UserRoleCreatedEvent>>
{
    private readonly ILogger<UserActivatedEventHandler> _logger;
    private readonly IDomainEventService _eventService;

    public UserActivatedEventHandler(ILogger<UserActivatedEventHandler> logger, IDomainEventService eventservice)
    {
        _logger = logger;
        _eventService = eventservice;
    }

    public async Task Handle(DomainEventNotification<UserRoleCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
    }
}

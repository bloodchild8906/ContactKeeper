using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.UserRoles.EventHandler;

public class UserRoleActivatedEventHandler : INotificationHandler<DomainEventNotification<UserRoleCreatedEvent>>
{
    private readonly ILogger<UserRoleActivatedEventHandler> _logger;
    private readonly IDomainEventService _eventService;

    public UserRoleActivatedEventHandler(ILogger<UserRoleActivatedEventHandler> logger, IDomainEventService eventservice)
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

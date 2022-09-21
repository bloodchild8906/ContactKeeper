using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.UserRoles.EventHandler;

public class UserRoleCreatedEventHandler : INotificationHandler<DomainEventNotification<UserRoleCreatedEvent>>
{
    private readonly ILogger<UserRoleActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public UserRoleCreatedEventHandler(ILogger<UserRoleActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<UserRoleCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.UserRole != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.Users.EventHandler;

public class UserCreatedEventHandler : INotificationHandler<DomainEventNotification<UserRoleCreatedEvent>>
{
    private readonly ILogger<UserActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public UserCreatedEventHandler(ILogger<UserActivatedEventHandler> logger, IDomainEventService domainEvent)
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

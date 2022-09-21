using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactCategory.EventHandler;

public class ContactCategoryCreatedEventHandler : INotificationHandler<DomainEventNotification<ContactCategoryCreatedEvent>>
{
    private readonly ILogger<ContactCategoryActivatedEventHandler> _logger;
    private readonly IDomainEventService _domainService;

    public ContactCategoryCreatedEventHandler(ILogger<ContactCategoryActivatedEventHandler> logger, IDomainEventService domainEvent)
    {
        _logger = logger;
        _domainService = domainEvent;
    }

    public async Task Handle(DomainEventNotification<ContactCategoryCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        if (domainEvent.ContactCategory != null)
        {
            await _domainService.Publish(domainEvent);
        }
    }
}

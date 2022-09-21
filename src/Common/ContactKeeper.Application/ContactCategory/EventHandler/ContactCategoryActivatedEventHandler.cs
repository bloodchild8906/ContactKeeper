using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ContactKeeper.Application.ContactCategory.EventHandler;

public class ContactCategoryActivatedEventHandler : INotificationHandler<DomainEventNotification<ContactCategoryCreatedEvent>>
{
    private readonly ILogger<ContactCategoryActivatedEventHandler> _logger;
    
    public ContactCategoryActivatedEventHandler(ILogger<ContactCategoryActivatedEventHandler> logger, IDomainEventService eventservice)
    {
        _logger = logger;
    }

    public async Task Handle(DomainEventNotification<ContactCategoryCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("ContactKeeper ContactKeeper.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
    }
}

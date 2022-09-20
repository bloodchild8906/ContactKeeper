using ContactKeeper.Domain.Common;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}

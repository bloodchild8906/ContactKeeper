using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class CityCreatedEvent : DomainEvent
{
    public CityCreatedEvent(City city)
    {
        City = city;
    }

    public City City { get; }
}

using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class CityActivatedEvent : DomainEvent
{
    public CityActivatedEvent(City city)
    {
        City = city;
    }

    public City City { get; }
}

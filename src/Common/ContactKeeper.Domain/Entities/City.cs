using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Event;

namespace ContactKeeper.Domain.Entities;

public class City : AuditableEntity, IHasDomainEvent
{
    public City()
    {
        Districts = new List<District>();
        DomainEvents= new List<DomainEvent>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; }


    public IList<District> Districts { get; set; }

    private bool _active;
    public bool Active
    {
        get => _active;
        set
        {
            if (value && _active == false)
            {
                DomainEvents.Add(new CityActivatedEvent(this));
            }

            _active = value;
        }
    }

    public List<DomainEvent> DomainEvents { get; set; }
}

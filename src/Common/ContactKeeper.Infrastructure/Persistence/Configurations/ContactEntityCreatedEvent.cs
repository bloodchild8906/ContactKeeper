
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class ContactEntityCreatedEvent : DomainEvent
{
    public ContactEntityCreatedEvent(ContactEntity contactEntity)
        => ContactEntity = contactEntity;

    public ContactEntity ContactEntity { get; }
}

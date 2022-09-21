using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class ContactPersonCreatedEvent : DomainEvent
{
    public ContactPersonCreatedEvent(ContactPerson contactPerson)
        => ContactPerson = contactPerson;
    public ContactPerson ContactPerson { get; }
}

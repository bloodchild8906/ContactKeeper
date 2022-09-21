using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class ContactPreferenceCreatedEvent : DomainEvent
{
    public ContactPreferenceCreatedEvent(ContactPreference contactPreference) => ContactPreference = contactPreference;

    public ContactPreference ContactPreference { get; }
}

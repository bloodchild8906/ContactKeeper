using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class ContactCategoryCreatedEvent : DomainEvent
{
    public ContactCategoryCreatedEvent(ContactCategory contactCategory)
        => ContactCategory = contactCategory;

    public ContactCategory ContactCategory { get; }
}

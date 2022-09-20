using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.ValueObjects;

namespace ContactKeeper.Domain.Entities;

public class ContactPerson : AuditableEntity, IHasDomainEvent
{
    public string Name { get; set; }
    public List<Email> Emails { get; set; }
    public Email PrimaryEmail { get; set; }
    public List<PhoneNumber> ContactNumbers { get; set; }
    public PhoneNumber PrimaryContactNumber { get; set; }
    public List<Note> Notes { get; set; }
    public ContactPreference ContactPreference { get; set; }
}

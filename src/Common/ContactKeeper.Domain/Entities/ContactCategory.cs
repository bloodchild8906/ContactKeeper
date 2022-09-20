using ContactKeeper.Domain.Common;

namespace ContactKeeper.Domain.Entities;

public class ContactCategory : AuditableEntity, IHasDomainEvent
{
    public string Name { get; set; }
    public ContactEntity ParentEntity { get; set; }
    public List<UserRole> CanBeUsedByRoles { get; set; }
}

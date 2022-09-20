using ContactKeeper.Domain.Common;

namespace ContactKeeper.Domain.Entities;

public class UserRole:AuditableEntity, IHasDomainEvent
{
    public string Name{ get; set; }
    public string Description { get; set; }
    public ContactEntity EntityParent { get; set; }
    public int AccessLevel { get; set; }
}

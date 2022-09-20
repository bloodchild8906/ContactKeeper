using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;

namespace ContactKeeper.Domain.Entities;

public class ContactEntity:AuditableEntity, IHasDomainEvent
{
    public string Name { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public EntityType TypeOfEntity { get; set; }
    public List<ContactCategory> Categories { get; set; }
    public ContactCategory? EntityCategory { get; set; }
    public ContactEntity? ParentEntity { get; set; }
    public ContactPreference EntityContactPreference { get; set; }
    public string CompanyCode { get; set; }
}

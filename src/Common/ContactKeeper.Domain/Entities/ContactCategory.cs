using ContactKeeper.Domain.Common;
using System;
using System.Collections.Generic;

namespace ContactKeeper.Domain.Entities
{
    public class ContactCategory : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContactEntity ParentEntity { get; set; }
        public List<UserRole> CanBeUsedByRoles { get; set; }
        public bool IsDeleted { get; set; }
    }
}

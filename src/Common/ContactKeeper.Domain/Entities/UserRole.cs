using ContactKeeper.Domain.Common;
using System;

namespace ContactKeeper.Domain.Entities
{
    public class UserRole:AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public ContactEntity EntityParent { get; set; }
        public int AccessLevel { get; set; }
        public bool Isdeleted { get; set; }

    }
}

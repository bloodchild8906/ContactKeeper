using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ContactKeeper.Domain.Entities
{
    public class ContactEntity:AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public EntityType TypeOfEntity { get; set; }
        public List<ContactCategory> Categories { get; set; }
        public ContactCategory? EntityCategory { get; set; }
        public ContactEntity? ParentEntity { get; set; }
        public ContactPreference EntityContactPreference { get; set; }
        public string CompanyCode { get; set; }
        public bool Isdeleted { get; set; }
    }
}

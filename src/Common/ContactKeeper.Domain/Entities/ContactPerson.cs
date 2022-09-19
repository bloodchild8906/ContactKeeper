using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ContactKeeper.Domain.Entities
{
    public class ContactPerson : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Email> Emails { get; set; }
        public Email PrimaryEmail { get; set; }
        public List<PhoneNumber> ContactNumbers { get; set; }
        public PhoneNumber PrimaryContactNumber { get; set; }
        public List<Note> Notes { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public bool IsDeleted { get; set; }

    }
}

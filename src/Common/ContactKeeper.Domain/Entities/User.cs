﻿using ContactKeeper.Domain.Common;
using System;
using System.Collections.Generic;

namespace ContactKeeper.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ContactEntity ContactDetail { get; set; }
        public List<ContactEntity> ContactList { get; set; }
        public ContactEntity ParentEntity { get; set;}
        public UserRole Role { get; set; }
    }
}

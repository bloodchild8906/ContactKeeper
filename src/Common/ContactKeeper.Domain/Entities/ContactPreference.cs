using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;
using ContactKeeper.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ContactKeeper.Domain.Entities
{
    public class ContactPreference : AuditableEntity
    {
        public Guid Id { get; set; }
        public bool UseActiveHours { get; set; }
        public Time ActiveHoursStart { get; set; }
        public Time ActiveHoursEnd { get; set; }
        public List<WeekDays> ContactableDays { get; set; }
        public List<ContactMethods> ContactPriorityOrder { get; set; }
        public bool IsDeleted { get; set; }

    }
}

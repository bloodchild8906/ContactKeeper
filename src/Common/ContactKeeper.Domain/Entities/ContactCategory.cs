using ContactKeeper.Domain.Common;
using System;

namespace ContactKeeper.Domain.Entities
{
    public class ContactCategory : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}

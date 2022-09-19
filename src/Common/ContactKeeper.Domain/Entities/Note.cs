using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ContactKeeper.Domain.Entities
{
    public class Note : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserRole> SharedWithRoles { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public NoteTypes NoteType { get; set; }
        public bool Shared { get; set; }
        public string NoteExecutionData { get; set; }
        public bool IsDeleted { get; set; }

    }
}

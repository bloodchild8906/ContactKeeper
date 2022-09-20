using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class UserRoleCreatedEvent : DomainEvent
{
    public UserRoleCreatedEvent(UserRole userRole) => UserRole = userRole;
    public UserRole UserRole { get; }
}

using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class UserCreatedEvent : DomainEvent
{
    public UserCreatedEvent(User user) 
        => User = user;

    public User User { get; }
}

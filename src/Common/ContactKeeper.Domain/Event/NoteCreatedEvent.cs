using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;

namespace ContactKeeper.Domain.Event;

public class NoteCreatedEvent : DomainEvent
{
    public NoteCreatedEvent(Note note) => Note = note;

    public Note Note { get; }
}

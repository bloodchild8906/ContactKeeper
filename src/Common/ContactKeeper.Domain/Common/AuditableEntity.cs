namespace ContactKeeper.Domain.Common;

public abstract class AuditableEntity: IHasDomainEvent
{
    protected AuditableEntity(Guid? id=null)
    {
        Id = id??new Guid();
    }

    public Guid Id { get; init; }
    public bool IsDeleted { get; set; } = false;
    public virtual List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}

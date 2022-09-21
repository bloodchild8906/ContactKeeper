using ContactKeeper.Domain.Common;

namespace ContactKeeper.Domain.Entities;

public class Village : AuditableEntity,IHasDomainEvent
{
    protected Village(Guid? id=null) : base(id)
    {

    }

    public string Name { get; set; }

    public Guid DistrictId { get; set; }
    public District District { get; set; }
    public List<DomainEvent> DomainEvents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

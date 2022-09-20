using ContactKeeper.Domain.Common;

namespace ContactKeeper.Domain.Entities;

public class District : AuditableEntity, IHasDomainEvent
{
    public string Name { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }


    public IList<Village> Villages { get; set; }
}

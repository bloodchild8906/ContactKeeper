using ContactKeeper.Domain.Entities;
using Mapster;

namespace ContactKeeper.Application.Dto;

public class DistrictDto : IRegister
{
    public DistrictDto()
    {
        Villages = new List<VillageDto>();
    }
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public string Name { get; set; }

    public IList<VillageDto> Villages { get; set; }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<District, DistrictDto>()
            .Map(dest => dest.Name, src => "Sig. " + src.Name, srcCond => srcCond.Name == "Karacabey")
            .Map(dest => dest.Name, src => "Sr. " + src.Name, srcCond => srcCond.Name == "Osmangazi")
            .Map(dest => dest.Name, src => src.Name);
    }
}

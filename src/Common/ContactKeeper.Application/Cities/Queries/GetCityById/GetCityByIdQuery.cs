using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Cities.Queries.GetCityById;

public class GetCityByIdQuery : IRequestWrapper<CityDto>
{
    public Guid CityId { get; set; }
}

public class GetCityByIdQueryHandler : IRequestHandlerWrapper<GetCityByIdQuery, CityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _context.Cities
            .Where(x => x.Id.Equals(request.CityId))
            .Include(d => d.Districts)
            .ThenInclude(v => v.Villages)
            .ProjectToType<CityDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return city != null ? ServiceResult.Success(city) : ServiceResult.Failed<CityDto>(ServiceError.NotFound);
    }
}

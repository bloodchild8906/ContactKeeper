using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactEntity.Queries;

public class GetAllContactEntitiesQuery : IRequestWrapper<List<ContactEntityDto>>
{

}

public class GetContactEntitiesQueryHandler : IRequestHandlerWrapper<GetAllContactEntitiesQuery, List<ContactEntityDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactEntitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<ContactEntityDto>>> Handle(GetAllContactEntitiesQuery request, CancellationToken cancellationToken)
    {
        List<ContactEntityDto> list = await _context.ContactEntities
            .ProjectToType<ContactEntityDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ContactEntityDto>>(ServiceError.NotFound);
    }
}

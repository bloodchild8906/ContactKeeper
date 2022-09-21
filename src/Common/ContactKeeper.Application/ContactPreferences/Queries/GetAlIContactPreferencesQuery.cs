using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPreferences.Queries;

public class GetAllContactPreferencesQuery : IRequestWrapper<List<ContactPreferenceDto>>
{

}

public class GetContactPreferencesQueryHandler : IRequestHandlerWrapper<GetAllContactPreferencesQuery, List<ContactPreferenceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactPreferencesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<ContactPreferenceDto>>> Handle(GetAllContactPreferencesQuery request, CancellationToken cancellationToken)
    {
        List<ContactPreferenceDto> list = await _context.ContactPreferences
            .ProjectToType<ContactPreferenceDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ContactPreferenceDto>>(ServiceError.NotFound);
    }
}

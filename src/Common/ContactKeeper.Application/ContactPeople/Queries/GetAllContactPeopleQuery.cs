using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPeople.Queries;

public class GetAllContactPeopleQuery : IRequestWrapper<List<ContactPersonDto>>
{

}

public class GetContactPeopleQueryHandler : IRequestHandlerWrapper<GetAllContactPeopleQuery, List<ContactPersonDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactPeopleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<ContactPersonDto>>> Handle(GetAllContactPeopleQuery request, CancellationToken cancellationToken)
    {
        List<ContactPersonDto> list = await _context.ContactPeople
            .ProjectToType<ContactPersonDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ContactPersonDto>>(ServiceError.NotFound);
    }
}

using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPeople.Queries;

public class GetContactPersonByIdQuery : IRequestWrapper<ContactPersonDto>
{
    public Guid Id { get; set; }
}

public class GetContactPersonByIdQueryHandler : IRequestHandlerWrapper<GetContactPersonByIdQuery, ContactPersonDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactPersonByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPersonDto>> Handle(GetContactPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var contactPerson = await _context.ContactPeople
            .Where(x => x.Equals(request.Id))
            .ProjectToType<ContactPersonDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return contactPerson != null ? ServiceResult.Success(contactPerson) : ServiceResult.Failed<ContactPersonDto>(ServiceError.NotFound);
    }
}

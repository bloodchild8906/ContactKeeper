using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactEntity.Queries;

public class GetContactEntityByIdQuery : IRequestWrapper<ContactEntityDto>
{
    public Guid Id { get; set; }
}

public class GetContactEntityByIdQueryHandler : IRequestHandlerWrapper<GetContactEntityByIdQuery, ContactEntityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactEntityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactEntityDto>> Handle(GetContactEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var contactEntities = await _context.ContactEntities
            .Where(x => x.Equals(request.Id))
            .ProjectToType<ContactEntityDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return contactEntities != null ? ServiceResult.Success(contactEntities) : ServiceResult.Failed<ContactEntityDto>(ServiceError.NotFound);
    }
}

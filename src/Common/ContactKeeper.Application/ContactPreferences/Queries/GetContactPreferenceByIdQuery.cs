using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPreferences.Queries;

public class GetContactPreferenceByIdQuery : IRequestWrapper<ContactPreferenceDto>
{
    public Guid Id { get; set; }
}

public class GetContactPreferenceByIdQueryHandler : IRequestHandlerWrapper<GetContactPreferenceByIdQuery, ContactPreferenceDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactPreferenceByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPreferenceDto>> Handle(GetContactPreferenceByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.ContactPreferences
            .Where(x => x.Equals(request.Id))
            .ProjectToType<ContactPreferenceDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return user != null ? ServiceResult.Success(user) : ServiceResult.Failed<ContactPreferenceDto>(ServiceError.NotFound);
    }
}

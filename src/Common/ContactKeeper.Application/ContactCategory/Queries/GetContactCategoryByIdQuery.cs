using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactCategory.Queries;

public class GetContactCategoryByNameQuery : IRequestWrapper<ContactCategoryDto>
{
    public string Name { get; set; }
}

public class GetContactCategoryByNameQueryHandler : IRequestHandlerWrapper<GetContactCategoryByNameQuery, ContactCategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactCategoryByNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactCategoryDto>> Handle(GetContactCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.ContactCategories
            .Where(x => x.Name.Equals(request))
            .Include(d => d.CanBeUsedByRoles)
            .ThenInclude(v => v.EntityParent)
            .ProjectToType<ContactCategoryDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return user != null ? ServiceResult.Success(user) : ServiceResult.Failed<ContactCategoryDto>(ServiceError.NotFound);
    }
}

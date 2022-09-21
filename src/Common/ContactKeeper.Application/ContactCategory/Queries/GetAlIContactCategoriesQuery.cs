using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactCategory.Queries;

public class GetAllContactCategoriesQuery : IRequestWrapper<List<ContactCategoryDto>>
{

}

public class GetContactCategoriesQueryHandler : IRequestHandlerWrapper<GetAllContactCategoriesQuery, List<ContactCategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<ContactCategoryDto>>> Handle(GetAllContactCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<ContactCategoryDto> list = await _context.ContactCategories
            .ProjectToType<ContactCategoryDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ContactCategoryDto>>(ServiceError.NotFound);
    }
}

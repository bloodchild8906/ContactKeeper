using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.UserRoles.Queries;

public class GetAllUserRolesQuery : IRequestWrapper<List<UserRoleDto>>
{

}

public class GetUserRolesQueryHandler : IRequestHandlerWrapper<GetAllUserRolesQuery, List<UserRoleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<UserRoleDto>>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        List<UserRoleDto> list = await _context.UserRole
            .ProjectToType<UserRoleDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<UserRoleDto>>(ServiceError.NotFound);
    }
}

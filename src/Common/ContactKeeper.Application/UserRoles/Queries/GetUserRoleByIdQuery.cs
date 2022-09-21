using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.UserRoles.Queries;

public class GetUserRoleByIdQuery : IRequestWrapper<UserRoleDto>
{
    public Guid Id { get; set; }
}

public class GetUserRoleByIdQueryHandler : IRequestHandlerWrapper<GetUserRoleByIdQuery, UserRoleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserRoleByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserRoleDto>> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _context.UserRole
            .Where(x => x.Equals(request.Id))
            .ProjectToType<UserRoleDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return userRoles != null ? ServiceResult.Success(userRoles) : ServiceResult.Failed<UserRoleDto>(ServiceError.NotFound);
    }
}

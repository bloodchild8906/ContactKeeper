using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Users.Queries;

public class GetAllUsersQuery : IRequestWrapper<List<UserDto>>
{

}

public class GetUsersQueryHandler : IRequestHandlerWrapper<GetAllUsersQuery, List<UserDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<UserDto> list = await _context.Users
            .ProjectToType<UserDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<UserDto>>(ServiceError.NotFound);
    }
}

using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Users.Queries;

public class GetUserByIdQuery : IRequestWrapper<UserDto>
{
    public Guid Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandlerWrapper<GetUserByIdQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(x => x.Equals(request.Id))
            .ProjectToType<UserDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return user != null ? ServiceResult.Success(user) : ServiceResult.Failed<UserDto>(ServiceError.NotFound);
    }
}

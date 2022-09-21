using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.UserRoles.Commands.Create;

public class CreateUserRoleCommand : IRequestWrapper<UserRoleDto>
{
    public string Name { get; set; }
}

public class CreateUserRoleCommandHandler : IRequestHandlerWrapper<CreateUserRoleCommand, UserRoleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserRoleDto>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new UserRole
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new UserRoleCreatedEvent(entity));

        await _context.UserRole.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<UserRoleDto>(entity));
    }
}

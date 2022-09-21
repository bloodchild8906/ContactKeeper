using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.Users.Commands.Create;

public class CreateUserCommand : IRequestWrapper<UserDto>
{
    public string Name { get; set; }
}

public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            UserName = request.Name
        };

        entity.DomainEvents.Add(new UserCreatedEvent(entity));

        await _context.Users.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<UserDto>(entity));
    }
}

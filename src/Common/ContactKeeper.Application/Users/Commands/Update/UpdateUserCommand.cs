using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.Users.Commands.Update;

public class UpdateUserCommand : IRequestWrapper<UserDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandlerWrapper<UpdateUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.UserName = request.Name;
        
        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<UserDto>(entity));
    }
}

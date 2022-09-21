using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.UserRoles.Commands.Update;

public class UpdateUserRoleCommand : IRequestWrapper<UserRoleDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}

public class UpdateUserRoleCommandHandler : IRequestHandlerWrapper<UpdateUserRoleCommand, UserRoleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserRoleDto>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserRole.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserRole), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<UserRoleDto>(entity));
    }
}

using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.UserRoles.Commands.Delete;

public class DeleteUserRoleCommand : IRequestWrapper<UserRoleDto>
{
    public Guid Id { get; set; }
}

public class DeleteUserRoleCommandHandler : IRequestHandlerWrapper<DeleteUserRoleCommand, UserRoleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteUserRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserRoleDto>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserRole
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserRole), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<UserRoleDto>(entity));
    }
}

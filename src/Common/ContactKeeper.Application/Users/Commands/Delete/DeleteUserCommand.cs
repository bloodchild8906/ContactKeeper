using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Users.Commands.Delete;

public class DeleteUserCommand : IRequestWrapper<UserDto>
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandlerWrapper<DeleteUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<UserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<UserDto>(entity));
    }
}

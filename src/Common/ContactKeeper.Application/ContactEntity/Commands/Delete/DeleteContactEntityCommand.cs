using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactEntity.Commands.Delete;

public class DeleteContactEntityCommand : IRequestWrapper<ContactEntityDto>
{
    public Guid Id { get; set; }
}

public class DeleteContactEntityCommandHandler : IRequestHandlerWrapper<DeleteContactEntityCommand, ContactEntityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteContactEntityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactEntityDto>> Handle(DeleteContactEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactEntities
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(City), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ContactEntityDto>(entity));
    }
}

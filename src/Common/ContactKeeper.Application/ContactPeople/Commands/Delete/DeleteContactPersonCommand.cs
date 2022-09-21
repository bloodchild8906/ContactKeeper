using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPeople.Commands.Delete;

public class DeleteContactPersonCommand : IRequestWrapper<ContactPersonDto>
{
    public Guid Id { get; set; }
}

public class DeleteContactPersonCommandHandler : IRequestHandlerWrapper<DeleteContactPersonCommand, ContactPersonDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteContactPersonCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPersonDto>> Handle(DeleteContactPersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactPeople
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactPerson), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ContactPersonDto>(entity));
    }
}

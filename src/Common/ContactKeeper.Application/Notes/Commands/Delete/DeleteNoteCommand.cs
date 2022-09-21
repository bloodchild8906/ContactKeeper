using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Notes.Commands.Delete;

public class DeleteNoteCommand : IRequestWrapper<NoteDto>
{
    public Guid Id { get; set; }
}

public class DeleteNoteCommandHandler : IRequestHandlerWrapper<DeleteNoteCommand, NoteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteNoteCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<NoteDto>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<NoteDto>(entity));
    }
}

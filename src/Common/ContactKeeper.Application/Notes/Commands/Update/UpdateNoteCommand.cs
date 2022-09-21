using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.Notes.Commands.Update;

public class UpdateNoteCommand : IRequestWrapper<NoteDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateNoteCommandHandler : IRequestHandlerWrapper<UpdateNoteCommand, NoteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateNoteCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<NoteDto>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<NoteDto>(entity));
    }
}

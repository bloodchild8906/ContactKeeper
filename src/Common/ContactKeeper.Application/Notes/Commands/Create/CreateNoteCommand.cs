using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.Notes.Commands.Create;

public class CreateNoteCommand : IRequestWrapper<NoteDto>
{
    public string Name { get; set; }
}

public class CreateNoteCommandHandler : IRequestHandlerWrapper<CreateNoteCommand, NoteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateNoteCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<NoteDto>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Note
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new NoteCreatedEvent(entity));

        await _context.Notes.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<NoteDto>(entity));
    }
}

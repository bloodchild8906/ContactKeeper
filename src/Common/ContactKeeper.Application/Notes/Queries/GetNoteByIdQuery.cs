using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Notes.Queries;

public class GetNoteByIdQuery : IRequestWrapper<NoteDto>
{
    public Guid Id { get; set; }
}

public class GetNoteByIdQueryHandler : IRequestHandlerWrapper<GetNoteByIdQuery, NoteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<NoteDto>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Notes
            .Where(x => x.Equals(request.Id))
            .ProjectToType<NoteDto>(_mapper.Config)
            .FirstOrDefaultAsync(cancellationToken);

        return user != null ? ServiceResult.Success(user) : ServiceResult.Failed<NoteDto>(ServiceError.NotFound);
    }
}

using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Notes.Queries;

public class GetAllNotesQuery : IRequestWrapper<List<NoteDto>>
{

}

public class GetNotesQueryHandler : IRequestHandlerWrapper<GetAllNotesQuery, List<NoteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<NoteDto>>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        List<NoteDto> list = await _context.Notes
            .ProjectToType<NoteDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<NoteDto>>(ServiceError.NotFound);
    }
}

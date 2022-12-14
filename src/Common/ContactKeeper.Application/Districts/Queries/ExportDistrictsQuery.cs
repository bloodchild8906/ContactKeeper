using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Security;
using ContactKeeper.Application.Dto;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Districts.Queries;

[Authorize(Roles = "Administrator")]
public class ExportDistrictsQuery : IRequest<ExportDto>
{
    public Guid CityId { get; set; }
}

public class ExportDistrictsQueryHandler : IRequestHandler<ExportDistrictsQuery, ExportDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;

    public ExportDistrictsQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportDto> Handle(ExportDistrictsQuery request, CancellationToken cancellationToken)
    {
        var result = new ExportDto();

        var records = await _context.Districts
            .Where(t => t.CityId.Equals(request.CityId))
            .ProjectToType<DistrictDto>(_mapper.Config)
            .ToListAsync(cancellationToken);

        result.Content = _fileBuilder.BuildDistrictsFile(records);
        result.ContentType = "text/csv";
        result.FileName = "Districts.csv";

        return await Task.FromResult(result);
    }
}

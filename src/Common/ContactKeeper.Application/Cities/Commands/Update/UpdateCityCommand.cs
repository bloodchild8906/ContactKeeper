using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.Cities.Commands.Update;

public class UpdateCityCommand : IRequestWrapper<CityDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateCityCommandHandler : IRequestHandlerWrapper<UpdateCityCommand, CityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CityDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cities.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(City), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;
        entity.Active = request.Active;

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<CityDto>(entity));
    }
}

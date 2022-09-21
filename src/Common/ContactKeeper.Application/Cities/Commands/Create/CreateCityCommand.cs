using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.Cities.Commands.Create;

public class CreateCityCommand : IRequestWrapper<CityDto>
{
    public Guid Id;
    public string Name { get; set; }
}

public class CreateCityCommandHandler : IRequestHandlerWrapper<CreateCityCommand, CityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = new City
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new CityCreatedEvent(entity));

        await _context.Cities.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<CityDto>(entity));
    }
}

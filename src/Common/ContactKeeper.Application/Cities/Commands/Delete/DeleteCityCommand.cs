using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Cities.Commands.Delete;

public class DeleteCityCommand : IRequestWrapper<CityDto>
{
    public Guid Id { get; set; }
}

public class DeleteCityCommandHandler : IRequestHandlerWrapper<DeleteCityCommand, CityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteCityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CityDto>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cities
            .Where(l => l.Id.Equals(request.Id))
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(City), request.Id);
        }

        _context.Cities.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<CityDto>(entity));
    }
}

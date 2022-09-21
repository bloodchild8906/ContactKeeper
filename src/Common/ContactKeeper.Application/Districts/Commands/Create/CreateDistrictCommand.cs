﻿using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.Districts.Commands.Create;

public class CreateDistrictCommand : IRequestWrapper<DistrictDto>
{
    public string Name { get; set; }

    public Guid CityId { get; set; }
}

public class CreateDistrictCommandHandler : IRequestHandlerWrapper<CreateDistrictCommand, DistrictDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateDistrictCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<DistrictDto>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
    {
        var entity = new District
        {
            Name = request.Name,
            CityId = request.CityId
        };

        await _context.Districts.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<DistrictDto>(entity));
    }
}

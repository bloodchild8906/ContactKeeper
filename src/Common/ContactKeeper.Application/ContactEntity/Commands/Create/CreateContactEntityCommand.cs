using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.ContactEntity.Commands.Create;

public class CreateContactEntityCommand : IRequestWrapper<ContactEntityDto>
{
    public string Name { get; set; }
}

public class CreateContactEntityCommandHandler : IRequestHandlerWrapper<CreateContactEntityCommand, ContactEntityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateContactEntityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactEntityDto>> Handle(CreateContactEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ContactEntity
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new ContactEntityCreatedEvent(entity));

        await _context.ContactEntities.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactEntityDto>(entity));
    }
}

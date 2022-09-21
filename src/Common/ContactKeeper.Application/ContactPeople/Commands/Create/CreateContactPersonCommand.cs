using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.ContactPeople.Commands.Create;

public class CreateContactPersonCommand : IRequestWrapper<ContactPersonDto>
{
    public string Name { get; set; }
}

public class CreateContactPersonCommandHandler : IRequestHandlerWrapper<CreateContactPersonCommand, ContactPersonDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateContactPersonCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPersonDto>> Handle(CreateContactPersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new ContactPerson
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new ContactPersonCreatedEvent(entity));

        await _context.ContactPeople.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactPersonDto>(entity));
    }
}

using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.ContactPreferences.Commands.Create;

public class CreateContactPreferenceCommand : IRequestWrapper<ContactPreferenceDto>
{
    public string Name { get; set; }
}

public class CreateContactPreferenceCommandHandler : IRequestHandlerWrapper<CreateContactPreferenceCommand, ContactPreferenceDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateContactPreferenceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPreferenceDto>> Handle(CreateContactPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = new ContactPreference();

        entity.DomainEvents.Add(new ContactPreferenceCreatedEvent(entity));

        await _context.ContactPreferences.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactPreferenceDto>(entity));
    }
}

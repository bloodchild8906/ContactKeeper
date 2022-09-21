using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Event;
using MapsterMapper;

namespace ContactKeeper.Application.ContactCategory.Commands.Create;

public class CreateContactCategoryCommand : IRequestWrapper<ContactCategoryDto>
{
    public string Name { get; set; }
}

public class CreateContactCategoryCommandHandler : IRequestHandlerWrapper<CreateContactCategoryCommand, ContactCategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateContactCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactCategoryDto>> Handle(CreateContactCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ContactCategory
        {
            Name = request.Name
        };

        entity.DomainEvents.Add(new ContactCategoryCreatedEvent(entity));

        await _context.ContactCategories.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactCategoryDto>(entity));
    }
}

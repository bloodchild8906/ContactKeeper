using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.ContactPeople.Commands.Update;

public class UpdateContactPersonCommand : IRequestWrapper<ContactPersonDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateContactPersonCommandHandler : IRequestHandlerWrapper<UpdateContactPersonCommand, ContactPersonDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateContactPersonCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPersonDto>> Handle(UpdateContactPersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactPeople.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactPerson), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactPersonDto>(entity));
    }
}

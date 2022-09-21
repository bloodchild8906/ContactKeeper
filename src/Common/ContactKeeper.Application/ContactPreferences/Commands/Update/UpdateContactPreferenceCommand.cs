using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.ContactPreferences.Commands.Update;

public class UpdateContactPreferenceCommand : IRequestWrapper<ContactPreferenceDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateContactPreferenceCommandHandler : IRequestHandlerWrapper<UpdateContactPreferenceCommand, ContactPreferenceDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateContactPreferenceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPreferenceDto>> Handle(UpdateContactPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactPreferences.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactPreference), request.Id);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactPreferenceDto>(entity));
    }
}

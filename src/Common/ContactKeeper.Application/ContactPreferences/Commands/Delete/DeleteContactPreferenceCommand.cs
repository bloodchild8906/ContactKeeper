using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPreferences.Commands.Delete;

public class DeleteContactPreferenceCommand : IRequestWrapper<ContactPreferenceDto>
{
    public Guid Id { get; set; }
}

public class DeleteContactPreferenceCommandHandler : IRequestHandlerWrapper<DeleteContactPreferenceCommand, ContactPreferenceDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteContactPreferenceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactPreferenceDto>> Handle(DeleteContactPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactPreferences
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactPreference), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ContactPreferenceDto>(entity));
    }
}

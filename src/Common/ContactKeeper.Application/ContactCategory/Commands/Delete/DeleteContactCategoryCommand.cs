using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactCategory.Commands.Delete;

public class DeleteContactCategoryCommand : IRequestWrapper<ContactCategoryDto>
{
    public Guid Id { get; set; }
}

public class DeleteContactCategoryCommandHandler : IRequestHandlerWrapper<DeleteContactCategoryCommand, ContactCategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteContactCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactCategoryDto>> Handle(DeleteContactCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactCategories
            .Where(l => l.Id.Equals(request.Id))
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactCategory), request.Id);
        }

        entity.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(_mapper.Map<ContactCategoryDto>(entity));
    }
}

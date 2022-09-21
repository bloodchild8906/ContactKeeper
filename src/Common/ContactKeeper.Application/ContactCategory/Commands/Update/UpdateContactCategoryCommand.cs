using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.ContactCategory.Commands.Update;

public class UpdateContactCategoryCommand : IRequestWrapper<ContactCategoryDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}

public class UpdateContactCategoryCommandHandler : IRequestHandlerWrapper<UpdateContactCategoryCommand, ContactCategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateContactCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactCategoryDto>> Handle(UpdateContactCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cities.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(City), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactCategoryDto>(entity));
    }
}

using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;

namespace ContactKeeper.Application.ContactEntity.Commands.Update;

public class UpdateContactEntityCommand : IRequestWrapper<ContactEntityDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}

public class UpdateContactEntityCommandHandler : IRequestHandlerWrapper<UpdateContactEntityCommand, ContactEntityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateContactEntityCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ContactEntityDto>> Handle(UpdateContactEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactEntities.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(City), request.Id);
        }
        if (!string.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;
        
        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ContactEntityDto>(entity));
    }
}

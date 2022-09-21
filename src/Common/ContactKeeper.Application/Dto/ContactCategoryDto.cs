using ContactKeeper.Domain.Common;

namespace ContactKeeper.Application.Dto;

public class ContactCategoryDto 
{
    public string Name { get; set; }
    public ContactEntityDto ParentEntity { get; set; }
    public List<UserRoleDto> CanBeUsedByRoles { get; set; }
}

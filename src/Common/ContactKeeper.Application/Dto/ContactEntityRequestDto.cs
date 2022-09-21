using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;

namespace ContactKeeper.Application.Dto;

public class ContactEntityDto 
{
    public string Name { get; set; }
    public List<UserRoleDto> UserRoles { get; set; }
    public EntityType TypeOfEntity { get; set; }
    public List<ContactCategoryDto> Categories { get; set; }
    public ContactCategoryDto? EntityCategory { get; set; }
    public ContactEntityDto? ParentEntity { get; set; }
    public ContactPreferenceDto EntityContactPreference { get; set; }
    public string CompanyCode { get; set; }
}

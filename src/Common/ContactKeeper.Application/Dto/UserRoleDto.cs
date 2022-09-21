using ContactKeeper.Domain.Common;

namespace ContactKeeper.Application.Dto;

public class UserRoleDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ContactEntityDto EntityParent { get; set; }
    public int AccessLevel { get; set; }
}

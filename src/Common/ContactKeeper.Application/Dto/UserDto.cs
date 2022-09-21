using ContactKeeper.Domain.Common;
using Mapster;

namespace ContactKeeper.Application.Dto;

public class UserDto : IRegister
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public ContactEntityDto ContactDetail { get; set; }
    public List<ContactEntityDto> ContactList { get; set; }
    public ContactEntityDto ParentEntity { get; set; }
    public UserRoleDto Role { get; set; }

    public void Register(TypeAdapterConfig config)
    {
    }
}

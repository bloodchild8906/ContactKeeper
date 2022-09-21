using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;

namespace ContactKeeper.Application.Dto;

public class NoteDto 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserRoleDto> SharedWithRoles { get; set; }
    public UserDto CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public UserDto UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public NoteTypes NoteType { get; set; }
    public bool Shared { get; set; }
    public string NoteExecutionData { get; set; }
}

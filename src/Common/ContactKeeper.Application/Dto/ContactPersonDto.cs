using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.ValueObjects;

namespace ContactKeeper.Application.Dto;

public class ContactPersonDto 
{
    public string Name { get; set; }
    public List<Email> Emails { get; set; }
    public Email PrimaryEmail { get; set; }
    public List<PhoneNumber> ContactNumbers { get; set; }
    public PhoneNumber PrimaryContactNumber { get; set; }
    public List<NoteDto> Notes { get; set; }
    public ContactPreferenceDto ContactPreference { get; set; }
}

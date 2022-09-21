using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Enums;
using ContactKeeper.Domain.ValueObjects;

namespace ContactKeeper.Application.Dto;

public class ContactPreferenceDto 
{
    public bool UseActiveHours { get; set; }
    public Time ActiveHoursStart { get; set; }
    public Time ActiveHoursEnd { get; set; }
    public List<WeekDays> ContactableDays { get; set; }
    public List<ContactMethods> ContactPriorityOrder { get; set; }
}

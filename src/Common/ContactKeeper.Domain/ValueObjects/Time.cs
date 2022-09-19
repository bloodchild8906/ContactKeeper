using System;
using System.Text.RegularExpressions;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects
{
    public class Time : ValueOf<string, Time>
    {

        private static bool IsValidTime(string thetime) => new Regex(@"^(20|21|22|23|[01]d|d)(([:][0-5]d){1,2})$").IsMatch(thetime);

        protected override void Validate()
        {
            if (IsValidTime(Value))
                throw new ArgumentException("The Input string is not a valid email address");
        }
    }
}

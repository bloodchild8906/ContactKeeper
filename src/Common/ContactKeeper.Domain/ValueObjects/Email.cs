using System;
using System.Text.RegularExpressions;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects
{
    public class Email : ValueOf<string, Email>
    {

        private Regex EmailRegex =>
            new(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase);

        private bool EmailIsValid(string emailAddress) =>
            EmailRegex.IsMatch(emailAddress);

        protected override void Validate()
        {
            if (!EmailIsValid(Value))
                throw new ArgumentException("The Input string is not a valid email address");
        }
    }
}

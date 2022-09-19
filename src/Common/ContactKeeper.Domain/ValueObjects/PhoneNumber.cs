using System;
using System.Text.RegularExpressions;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects
{
    public class PhoneNumber : ValueOf<string, PhoneNumber>
    {
        private static Regex PhoneNumberRegex => new("^\\+?[1-9][0-9]{7,14}$", RegexOptions.IgnoreCase);

        private bool PhoneNumberIsValid(string phoneNumber) => PhoneNumberRegex.IsMatch(phoneNumber);

        protected override void Validate()
        {
            if (!PhoneNumberIsValid(Value))
                throw new ArgumentException("The Input string is not a valid email address");
        }
    }
}

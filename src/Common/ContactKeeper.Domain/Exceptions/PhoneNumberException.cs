using System;

namespace ContactKeeper.Domain.Exceptions
{
    public class PhoneNumberException : Exception
    {
        public PhoneNumberException(string emailInput) : base($"the input {emailInput} is not a valid Phone Number")
        {
        }
    }
}

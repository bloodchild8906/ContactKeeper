using System;

namespace ContactKeeper.Domain.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException(string emailInput) : base($"the input {emailInput} is not a valid email address")
        {
        }
    }
}

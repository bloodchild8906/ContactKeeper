namespace ContactKeeper.Domain.Exceptions;

public class PhoneNumberException : Exception
{
    public PhoneNumberException(string? emailInput) : 
        base(emailInput is not null?
            $"the input {emailInput} is not a valid Phone Number":
            $"the input was null")
    {
    }
}

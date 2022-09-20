using ContactKeeper.Domain.Exceptions;
using PhoneNumbers;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects;

public class PhoneNumber : ValueOf<string, PhoneNumber>
{
    private static bool IsValidNumber(string aNumber)
    {
        bool result = false;

        aNumber = aNumber.Trim();

        if (aNumber.StartsWith("00"))
        {
            // Replace 00 at beginning with +
            aNumber = "+" + aNumber.Remove(0, 2);
        }

        try
        {
            result = PhoneNumberUtil.IsViablePhoneNumber(aNumber);
        }
        catch
        {

            // Exception means is no valid number
        }

        return result;
    }

    protected override void Validate()
    {
        if (!IsValidNumber(Value))
            throw new PhoneNumberException(Value);
    }
}

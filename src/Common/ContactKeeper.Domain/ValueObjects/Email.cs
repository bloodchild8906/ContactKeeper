using ContactKeeper.Domain.Exceptions;
using System.Net.Mail;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects;

public class Email : ValueOf<string, Email>
{
    protected override void Validate()
    {
        try
        {
            var emailAddress = new MailAddress(Value);
        }
        catch
        {
            throw new EmailException(Value);
        }
    }
}

using ContactKeeper.Domain.Exceptions;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects
{
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
}

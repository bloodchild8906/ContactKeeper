using ContactKeeper.Domain.Exceptions;
using ContactKeeper.Domain.ValueObjects;
using NUnit.Framework;

namespace ContactKeeper.Domain.UnitTests.ValueObjects;

[TestFixture]
public class EmailTests
{
    [TestCase("tony@example.com")]
    [TestCase("tony.stark@example.net")]
    [TestCase("tony@example.co.uk")]
    [TestCase("tony@example")]
    public void CreateEmailValueObject_SuccessState(string emailToValidate) 
        => Assert.IsTrue(Email.From(emailToValidate).Value.Equals(emailToValidate));

    [TestCase("tony.example.com")]
    [TestCase("tony@stark@example.net")]
    [TestCase("tony@.example.co.uk")]
    public void CreateEmailValueObject_FailureState(string emailToValidate) 
        => Assert.Throws<EmailException>(()=>Email.From(emailToValidate));
}

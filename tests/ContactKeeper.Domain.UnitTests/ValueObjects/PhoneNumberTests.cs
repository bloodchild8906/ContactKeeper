using ContactKeeper.Domain.Exceptions;
using ContactKeeper.Domain.ValueObjects;
using NUnit.Framework;

namespace ContactKeeper.Domain.UnitTests.ValueObjects
{
    [TestFixture]
    public class PhoneNumberTests
    {

        [TestCase("(011) 154-123-4567")]
        [TestCase("154-123-4567")]
        [TestCase("+380 44 123 45 67")]
        [TestCase("11 4-123-4567")]
        public void CreatePhoneNumberValueObject_SuccessState(string phoneNumberToValidate)
            => Assert.IsTrue(PhoneNumber.From(phoneNumberToValidate).Value.Equals(phoneNumberToValidate));

        [TestCase("+38 (044) +1234567")]
        [TestCase("12345678$%123zzzz45")]
        [TestCase("t86827698369182")]
        public void CreatePhoneNumberValueObject_FailureState(string phoneNumberToValidate)
            => Assert.Throws<PhoneNumberException>(() => PhoneNumber.From(phoneNumberToValidate));
    }
}

using ContactKeeper.Domain.Exceptions;
using ContactKeeper.Domain.ValueObjects;
using NUnit.Framework;

namespace ContactKeeper.Domain.UnitTests.ValueObjects
{
    [TestFixture, Author("Michael Brown"), Category("ValueObjects")]
    public class TimeTests
    {
        [TestCase("17:45")]
        [TestCase("10:15")]
        [TestCase("05:15")]
        public void CreateTimeValueObject_SuccessState(string phoneNumberToValidate)
           => Assert.IsTrue(Time.From(phoneNumberToValidate).Value.Equals(phoneNumberToValidate));

        [TestCase("10:60")]
        [TestCase("1745")]
        [TestCase("190:0")]
        [TestCase("20h:15m")]
        public void CreateTimeValueObject_FailureState(string timeToValidate)
            => Assert.Throws<TimeException>(() => Time.From(timeToValidate));

    }
}

using ContactKeeper.Domain.Exceptions;
using System;
using System.Text.RegularExpressions;
using ValueOf;

namespace ContactKeeper.Domain.ValueObjects
{
    public class Time : ValueOf<string, Time>
    {
        
        protected override void Validate()
        {
            if (!new Regex(@"([01]?[0-9]|2[0-3]):[0-5][0-9]").IsMatch(Value))
                throw new TimeException(Value);
        }
    }
}

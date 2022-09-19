using System;

namespace ContactKeeper.Domain.Exceptions
{
    public class TimeException : Exception
    {
        public TimeException(string time) : base($"please insert a time only eg: 17:45 what was recieved is {time}")
        {

        }
    }
}

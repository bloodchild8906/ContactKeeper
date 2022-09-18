using System;
using ContactKeeper.Application.Common.Interfaces;

namespace ContactKeeper.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

using ContactKeeper.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using ValueOf;

namespace ContactKeeper.Domain.Entities
{
    public class Email : ValueOf<string, Email>
    {

    }
    public class PhoneNumber : ValueOf<string, PhoneNumber>
    {

    }

    public class ContactPreference : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
    public enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    public enum ContactMethods { PhoneCall, TextMessage, Email }
    public enum ContactTypes { Company, Department, Individual }
    public enum NoteTypes { General, Reminder, Actionable }


    public class ContactPerson : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
    public class ContactCategory : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }

    public class DialCode : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortIsoCode { get; }

        /// <summary>
        /// 
        /// </summary>
        public string LongIsoCode { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="shortIsoCode"></param>
        /// <param name="longIsoCode"></param>
        public DialCode(string countryCode, string shortIsoCode, string longIsoCode)
        {
            CountryCode = countryCode;
            ShortIsoCode = shortIsoCode;
            LongIsoCode = longIsoCode;
        }
    }
}

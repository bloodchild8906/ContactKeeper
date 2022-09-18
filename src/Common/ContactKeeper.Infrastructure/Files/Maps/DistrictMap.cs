using System.Globalization;
using ContactKeeper.Application.Dto;
using CsvHelper.Configuration;

namespace ContactKeeper.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).Convert(_ => "");
        }
    }
}

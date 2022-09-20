using System.Globalization;
using System.Text;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Dto;
using ContactKeeper.Infrastructure.Files.Maps;
using CsvHelper;

namespace ContactKeeper.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<DistrictMap>();
            csvWriter.WriteRecords(cities);
        }

        return memoryStream.ToArray();
    }
}

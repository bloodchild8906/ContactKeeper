using System.Collections.Generic;
using ContactKeeper.Application.Dto;

namespace ContactKeeper.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Districts.Commands.Create;
using ContactKeeper.Application.Villages.Queries.GetVillagesWithPagination;
using ContactKeeper.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static ContactKeeper.Application.IntegrationTests.Testing;

namespace ContactKeeper.Application.IntegrationTests.Villages.Queries;

public class GetAllVillagesWithPaginationTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllCities()
    {
        //    var city = await SendAsync(new CreateCityCommand
        //    {
        //        Name = "Muğla"
        //    });

        //    var district = await SendAsync(new CreateDistrictCommand
        //    {
        //        Name = "Bodrum",
        //        CityId = city.Data.Id
        //    });

        //    List<string> villages = new List<string> { "Çömlekçi", "Müsgebi", "Karakaya", "Etrim", "Sandima", "Akyarlar", "Gündoğan" };




        //    var result = await SendAsync(query);

        //    result.Should().NotBeNull();
        //    result.Succeeded.Should().BeTrue();
        //    result.Data.Items.Count.Should().Be(3);
        //    result.Data.TotalCount.Should().Be(7);
        //}
    }
}

using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Cities.Commands.Delete;
using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static ContactKeeper.Application.IntegrationTests.Testing;

namespace ContactKeeper.Application.IntegrationTests.Cities.Commands;

public class DeleteCityTests : TestBase
{
    [Test]
    public void ShouldRequireValidCityId()
    {
        var command = new DeleteCityCommand { Id = 99 };

        FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteCity()
    {
        var city = await SendAsync(new CreateCityCommand
        {
            Name = "Kayseri"
        });

        await SendAsync(new DeleteCityCommand
        {
            Id = city.Data.Id
        });

        var list = await FindAsync<City>(city.Data.Id);

        list.Should().BeNull();
    }
}

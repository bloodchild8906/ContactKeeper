using System;
using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Districts.Commands.Create;
using ContactKeeper.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static ContactKeeper.Application.IntegrationTests.Testing;

namespace ContactKeeper.Application.IntegrationTests.Districts.Commands;

public class CreateDistrictTests
{
    [Test]
    public void ShouldRequireMinimumFields()
    {
        var command = new CreateDistrictCommand();

        FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();

    }

    [Test]
    public async Task ShouldCreateDistrict()
    {
        var city = await SendAsync(new CreateCityCommand
        {
            Id=new Guid(),
            Name = "Bursa"
        });

        var userId = await RunAsDefaultUserAsync();

        var command = new CreateDistrictCommand
        {
            Name = "Karacabey",
            CityId = city.Data.Id
        };

        var result = await SendAsync(command);

        var list = await FindAsync<District>(result.Data.Id);

        list.Should().NotBeNull();
        list.Name.Should().Be(command.Name);
    }
}

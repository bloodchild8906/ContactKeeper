using System;
using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Cities.Commands.Update;
using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static ContactKeeper.Application.IntegrationTests.Testing;

namespace ContactKeeper.Application.IntegrationTests.Cities.Commands;

public class UpdateCityTests : TestBase
{
    [Test]
    public void ShouldRequireValidCityId()
    {
        var command = new UpdateCityCommand
        {
            Id = new Guid(),
            Name = "Kayseri"
        };

        FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueName()
    {
        var city = await SendAsync(new CreateCityCommand
        {
            Name = "Malatya"
        });

        await SendAsync(new CreateCityCommand
        {
            Name = "Denizli"
        });

        var command = new UpdateCityCommand
        {
            Id = city.Data.Id,
            Name = "Denizli"
        };

        FluentActions.Invoking(() =>
                SendAsync(command))
            .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("Name")).Result
            .And.Errors["Name"].Should().Contain("The specified city already exists. If you just want to activate the city leave the name field blank!");
    }

    [Test]
    public async Task ShouldUpdateCity()
    {
        var userId = await RunAsDefaultUserAsync();

        var result = await SendAsync(new CreateCityCommand
        {
            Name = "Kayyysseri"
        });

        var command = new UpdateCityCommand
        {
            Id = result.Data.Id,
            Name = "Kayseri"
        };

        await SendAsync(command);

        var city = await FindAsync<City>(result.Data.Id);

        city.Name.Should().Be(command.Name);
    }
}

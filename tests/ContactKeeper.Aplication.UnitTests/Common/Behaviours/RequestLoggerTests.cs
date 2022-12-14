using System;
using System.Threading;
using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Common.Behaviours;
using ContactKeeper.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ContactKeeper.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private readonly Mock<ILogger<CreateCityCommand>> _logger;
    private readonly Mock<ICurrentUserService> _currentUserService;
    private readonly Mock<IIdentityService> _identityService;


    public RequestLoggerTests()
    {
        _logger = new Mock<ILogger<CreateCityCommand>>();

        _currentUserService = new Mock<ICurrentUserService>();

        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(new System.Guid());

        var requestLogger = new LoggingBehaviour<CreateCityCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateCityCommand { Name = "Bursa" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateCityCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateCityCommand { Name = "Bursa" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(Guid.Empty), Times.Never);
    }
}

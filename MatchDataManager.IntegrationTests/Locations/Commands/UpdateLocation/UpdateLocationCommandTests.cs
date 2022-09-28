using MatchDataManager.Application.Common.Exceptions.Location;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Locations.Commands.UpdateLocation;
using MatchDataManager.IntegrationTests.Locations.Mocks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandTests
{
    private readonly ILocationCommandsRepository _mockLocationCommandsRepository;
    private readonly ILocationCommandsRepository _mockLocationCommandsRepositoryWithException;

    public UpdateLocationCommandTests()
    {
        _mockLocationCommandsRepository = MockILocationCommandsRepository.GetLocationRepository();
        _mockLocationCommandsRepositoryWithException = MockILocationCommandsRepository.GetLocationRepositoryWithException();
    }

    [Fact]
    public async Task UpdateLocationCommandShouldSucceeded()
    {
        var command = new UpdateLocationCommand(Guid.NewGuid(), "R-K", "Rybnik");
        var cancellationToken = new CancellationTokenSource();

        var handler = new UpdateLocationCommandHandler(
            _mockLocationCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.Equal(Unit.Value, result);
    }

    [Fact]
    public async Task UpdateLocationCommandShouldThrowException()
    {
        var command = new UpdateLocationCommand(Guid.NewGuid(), "R-K", "Rybnik");
        var cancellationToken = new CancellationTokenSource();

        var handler = new UpdateLocationCommandHandler(
            _mockLocationCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<LocationNullException>(exception);
    }
}

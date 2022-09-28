using MatchDataManager.Application.Common.Exceptions.Location;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Locations.Commands.DeleteLocation;
using MatchDataManager.IntegrationTests.Locations.Mocks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Locations.Commands.DeleteLocation;

public class DeleteLocationCommandTests
{
    private readonly ILocationCommandsRepository _mockLocationCommandsRepository;
    private readonly ILocationCommandsRepository _mockLocationCommandsRepositoryWithException;

    public DeleteLocationCommandTests()
    {
        _mockLocationCommandsRepository = MockILocationCommandsRepository.GetLocationRepository();
        _mockLocationCommandsRepositoryWithException = MockILocationCommandsRepository.GetLocationRepositoryWithException();
    }

    [Fact]
    public async Task DeleteLocationCommandShouldSucceeded()
    {
        var command = new DeleteLocationCommand(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new DeleteLocationCommandHandler(
            _mockLocationCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.Equal(Unit.Value, result);
    }

    [Fact]
    public async Task DeleteLocationCommandShouldThrowException()
    {
        var command = new DeleteLocationCommand(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new DeleteLocationCommandHandler(
            _mockLocationCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<LocationNullException>(exception);
    }
}

using MatchDataManager.Application.Common.Exceptions.Repository;
using MatchDataManager.Application.Common.Exceptions.Shared;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Locations.Commands.CreateLocation;
using MatchDataManager.IntegrationTests.Locations.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Locations.Commands.CreateLocation;

public class CreateLocationCommandTests
{
    private readonly ILocationCommandsRepository _mockLocationCommandsRepository;
    private readonly ILocationCommandsRepository _mockLocationCommandsRepositoryWithException;

    public CreateLocationCommandTests()
    {
        _mockLocationCommandsRepository = MockILocationCommandsRepository.GetLocationRepository();
        _mockLocationCommandsRepositoryWithException = MockILocationCommandsRepository.GetLocationRepositoryWithException();
    }

    [Fact]
    public async Task CreateLocationCommandShouldSucceeded()
    {
        var command = new CreateLocationCommand("RK", "Rybnik");
        var cancellationToken = new CancellationTokenSource();

        var handler = new CreateLocationCommandHandler(
            _mockLocationCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.IsType<Guid>(result.Id);
        Assert.Equal(result.Name, command.Name);
        Assert.Equal(result.City, command.City);
    }

    [Fact]
    public async Task CreateLocationCommandShouldThrowException()
    {
        var command = new CreateLocationCommand("RK", "Rybnik");
        var cancellationToken = new CancellationTokenSource();

        var handler = new CreateLocationCommandHandler(
            _mockLocationCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<SaveToDatabaseException>(exception);
    }
}

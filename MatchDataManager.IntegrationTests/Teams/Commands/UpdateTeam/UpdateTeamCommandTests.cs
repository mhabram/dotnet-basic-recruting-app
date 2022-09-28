using MatchDataManager.Application.Common.Exceptions.Team;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Teams.Commands.UpdateTeam;
using MatchDataManager.IntegrationTests.Teams.Mocks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandTests
{
    private readonly ITeamCommandsRepository _mockTeamCommandsRepository;
    private readonly ITeamCommandsRepository _mockTeamCommandsRepositoryWithException;

    public UpdateTeamCommandTests()
    {
        _mockTeamCommandsRepository = MockITeamCommandsRepository.GetTeamRepository();
        _mockTeamCommandsRepositoryWithException = MockITeamCommandsRepository.GetTeamRepositoryWithException();
    }

    [Fact]
    public async Task UpdateTeamCommandShouldSucceeded()
    {
        var command = new UpdateTeamCommand(Guid.NewGuid(), "RK Team", "Karol");
        var cancellationToken = new CancellationTokenSource();

        var handler = new UpdateTeamCommandHandler(
            _mockTeamCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.Equal(Unit.Value, result);
    }

    [Fact]
    public async Task UpdateTeamCommandShouldThrowException()
    {
        var command = new UpdateTeamCommand(Guid.NewGuid(), "R-K Team", "Robert");
        var cancellationToken = new CancellationTokenSource();

        var handler = new UpdateTeamCommandHandler(
            _mockTeamCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<TeamNullException>(exception);
    }
}

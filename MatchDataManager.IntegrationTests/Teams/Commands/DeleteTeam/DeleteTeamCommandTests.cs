using MatchDataManager.Application.Common.Exceptions.Team;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Teams.Commands.DeleteTeam;
using MatchDataManager.IntegrationTests.Teams.Mocks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Teams.Commands.DeleteTeam;

public class DeleteTeamCommandTests
{
    private readonly ITeamCommandsRepository _mockTeamCommandsRepository;
    private readonly ITeamCommandsRepository _mockTeamCommandsRepositoryWithException;

    public DeleteTeamCommandTests()
    {
        _mockTeamCommandsRepository = MockITeamCommandsRepository.GetTeamRepository();
        _mockTeamCommandsRepositoryWithException = MockITeamCommandsRepository.GetTeamRepositoryWithException();
    }

        [Fact]
    public async Task DeleteTeamCommandShouldSucceeded()
    {
        var command = new DeleteTeamCommand(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new DeleteTeamCommandHandler(
            _mockTeamCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.Equal(Unit.Value, result);
    }

    [Fact]
    public async Task DeleteTeamCommandShouldThrowException()
    {
        var command = new DeleteTeamCommand(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new DeleteTeamCommandHandler(
            _mockTeamCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<TeamNullException>(exception);
    }
}

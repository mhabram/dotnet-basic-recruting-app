using MatchDataManager.Application.Common.Exceptions.Repository;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Teams.Commands.CreateTeam;
using MatchDataManager.IntegrationTests.Teams.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Teams.Commands.CreateTeam;

public class CreateTeamCommandTests
{
    private readonly ITeamCommandsRepository _mockTeamCommandsRepository;
    private readonly ITeamCommandsRepository _mockTeamCommandsRepositoryWithException;

    public CreateTeamCommandTests()
    {
        _mockTeamCommandsRepository = MockITeamCommandsRepository.GetTeamRepository();
        _mockTeamCommandsRepositoryWithException = MockITeamCommandsRepository.GetTeamRepositoryWithException();
    }

    [Fact]
    public async Task CreateTeamCommandShouldSucceeded()
    {
        var command = new CreateTeamCommand("GL Team", "Karol");
        var cancellationToken = new CancellationTokenSource();

        var handler = new CreateTeamCommandHandler(
            _mockTeamCommandsRepository);

        var result = await handler.Handle(command, cancellationToken.Token);

        Assert.IsType<Guid>(result.Id);
        Assert.Equal(result.Name, command.Name);
        Assert.Equal(result.CoachName, command.CoachName);
    }

    [Fact]
    public async Task CreateTeamCommandShouldThrowException()
    {
        var command = new CreateTeamCommand("GL Team", "Karol");
        var cancellationToken = new CancellationTokenSource();

        var handler = new CreateTeamCommandHandler(
            _mockTeamCommandsRepositoryWithException);

        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, cancellationToken.Token));

        Assert.IsType<SaveToDatabaseException>(exception);
    }
}

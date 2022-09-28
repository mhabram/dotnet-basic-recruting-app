using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Teams.Queries.GetTeams;
using MatchDataManager.IntegrationTests.Teams.Mocks;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Teams.Queries.GetTeams;

public class GetTeamsQueryTests
{
    private readonly ITeamQueriesRepository _mockTeamQueriesRepository;
    private readonly ITeamQueriesRepository _mockTeamQueriesRepositoryWithNull;

    public GetTeamsQueryTests()
    {
        _mockTeamQueriesRepository = MockITeamQueriesRepository.GetTeamRepository();
        _mockTeamQueriesRepositoryWithNull = MockITeamQueriesRepository.GetTeamRepositoryWithNull();
    }

    [Fact]
    public async Task GetTeamsQueryShouldSucceeded()
    {
        var query = new GetTeamsQuery();
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetTeamsQueryHandler(
            _mockTeamQueriesRepository);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.NotEmpty(result);
        
        foreach(var team in result)
        {
            var expected = TeamTestData.Teams
                .First(x => x.Id == team.Id);
            
            Assert.NotNull(expected);
            Assert.Equal(expected.Name, team.Name);
            Assert.Equal(expected.CoachName, team.CoachName);
        }
    }

    [Fact]
    public async Task GetTeamsShouldReturnNull()
    {
        var query = new GetTeamsQuery();
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetTeamsQueryHandler(
            _mockTeamQueriesRepositoryWithNull);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.Empty(result);
    }
}

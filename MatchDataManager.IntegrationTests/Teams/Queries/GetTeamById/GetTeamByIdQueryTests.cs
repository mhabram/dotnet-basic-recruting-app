using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Teams.Queries.GetTeamById;
using MatchDataManager.IntegrationTests.Teams.Mocks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Teams.Queries.GetTeamById;

public class GetTeamByIdQueryTests
{
    private readonly ITeamQueriesRepository _mockTeamQueriesRepository;
    private readonly ITeamQueriesRepository _mockTeamQueriesRepositoryWithNull;

    public GetTeamByIdQueryTests()
    {
        _mockTeamQueriesRepository = MockITeamQueriesRepository.GetTeamRepository();
        _mockTeamQueriesRepositoryWithNull = MockITeamQueriesRepository.GetTeamRepositoryWithNull();
    }

    [Fact]
    public async Task GetTeamByIdQueryShouldSucceeded()
    {
        var expected = TeamTestData.Teams.First();
        var query = new GetTeamByIdQuery(expected.Id);
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetTeamByIdQueryHandler(
            _mockTeamQueriesRepository);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.NotNull(result);
        Assert.Equal(expected.Id, result.Id);
        Assert.Equal(expected.Name, result.Name);
        Assert.Equal(expected.CoachName, result.CoachName);
    }

    [Fact]
    public async Task GetTeamByIdQueryShouldReturnNull()
    {
        var query = new GetTeamByIdQuery(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetTeamByIdQueryHandler(
            _mockTeamQueriesRepositoryWithNull);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.Null(result);
    }
}

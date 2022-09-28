using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Locations.Queries.GetLocations;
using MatchDataManager.IntegrationTests.Locations.Mocks;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Locations.Queries.GetLocations;

public class GetLocationsQueryTests
{
    private readonly ILocationQueriesRepository _mockLocationQueriesRepository;
    private readonly ILocationQueriesRepository _mockLocationQueriesRepositoryWithNull;

    public GetLocationsQueryTests()
    {
        _mockLocationQueriesRepository = MockILocationQueriesRepository.GetLocationRepository();
        _mockLocationQueriesRepositoryWithNull = MockILocationQueriesRepository.GetLocationRepositoryWithNull();
    }

    [Fact]
    public async Task GetLocationsQueryShouldSucceeded()
    {
        var query = new GetLocationsQuery();
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetLocationsQueryHandler(
            _mockLocationQueriesRepository);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.NotEmpty(result);

        foreach (var team in result)
        {
            var expected = LocationTestData.Locations
                .First(x => x.Id == team.Id);

            Assert.NotNull(expected);
            Assert.Equal(expected.Name, team.Name);
            Assert.Equal(expected.City, team.City);
        }
    }

    [Fact]
    public async Task GetLocationsShouldReturnNull()
    {
        var query = new GetLocationsQuery();
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetLocationsQueryHandler(
            _mockLocationQueriesRepositoryWithNull);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.Empty(result);
    }
}

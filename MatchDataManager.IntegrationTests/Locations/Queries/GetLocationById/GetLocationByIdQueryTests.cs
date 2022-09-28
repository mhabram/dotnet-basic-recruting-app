using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Locations.Queries.GetLocationById;
using MatchDataManager.IntegrationTests.Locations.Mocks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MatchDataManager.IntegrationTests.Locations.Queries.GetLocationById;

public class GetLocationByIdQueryTests
{
    private readonly ILocationQueriesRepository _mockLocationQueriesRepository;
    private readonly ILocationQueriesRepository _mockLocationQueriesRepositoryWithNull;

    public GetLocationByIdQueryTests()
    {
        _mockLocationQueriesRepository = MockILocationQueriesRepository.GetLocationRepository();
        _mockLocationQueriesRepositoryWithNull = MockILocationQueriesRepository.GetLocationRepositoryWithNull();
    }

    [Fact]
    public async Task GetLocationByIdQueryShouldSucceeded()
    {
        var expected = LocationTestData.Locations.First();
        var query = new GetLocationByIdQuery(expected.Id);
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetLocationByIdQueryHandler(
            _mockLocationQueriesRepository);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.NotNull(result);
        Assert.Equal(expected.Id, result.Id);
        Assert.Equal(expected.Name, result.Name);
        Assert.Equal(expected.City, result.City);
    }

    [Fact]
    public async Task GetLocationByIdQueryShouldReturnNull()
    {
        var query = new GetLocationByIdQuery(Guid.NewGuid());
        var cancellationToken = new CancellationTokenSource();

        var handler = new GetLocationByIdQueryHandler(
            _mockLocationQueriesRepositoryWithNull);

        var result = await handler.Handle(query, cancellationToken.Token);

        Assert.Null(result);
    }
}

using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using Moq;
using System.Threading;

namespace MatchDataManager.UnitTests.Locations.Mocks;

internal static class MockILocationQueriesRepository
{
    internal static ILocationQueriesRepository GetLocationUniqueName(bool isUniqueName)
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.IsUniqueLocationNameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(isUniqueName);

        return mockLocationQueriesRepository.Object;
    }
}

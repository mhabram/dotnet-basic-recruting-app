using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using Moq;
using System.Threading;

namespace MatchDataManager.UnitTests.Locations.Mocks;

internal static class MockILocationQueriesRepository
{
    internal static ILocationQueriesRepository GetLocationUniqueNameFalse()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.IsUniqueLocationName(It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

        return mockLocationQueriesRepository.Object;
    }

    internal static ILocationQueriesRepository GetLocationUniqueNameTrue()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.IsUniqueLocationName(It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

        return mockLocationQueriesRepository.Object;
    }
}

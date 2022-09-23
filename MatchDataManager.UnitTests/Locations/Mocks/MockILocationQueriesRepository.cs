using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using Moq;

namespace MatchDataManager.UnitTests.Locations.Mocks;

internal static class MockILocationQueriesRepository
{
    internal static ILocationQueriesRepository GetLocationUniqueNameFalse()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.IsUniqueName(It.IsAny<string>()))
                .ReturnsAsync(false);

        return mockLocationQueriesRepository.Object;
    }

    internal static ILocationQueriesRepository GetLocationUniqueNameTrue()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.IsUniqueName(It.IsAny<string>()))
                .ReturnsAsync(true);

        return mockLocationQueriesRepository.Object;
    }
}

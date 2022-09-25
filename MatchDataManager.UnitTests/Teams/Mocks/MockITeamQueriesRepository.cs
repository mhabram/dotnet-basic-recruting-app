using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using Moq;
using System.Threading;

namespace MatchDataManager.UnitTests.Teams.Mocks;

internal class MockITeamQueriesRepository
{
    internal static ITeamQueriesRepository GetTeamUniqueName(bool isUniqueName)
    {
        var mockTeamQueriesRepository = new Mock<ITeamQueriesRepository>()
            .Setup(s =>
                s.IsUniqueTeamNameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(isUniqueName);

        return mockTeamQueriesRepository.Object;
    }
}

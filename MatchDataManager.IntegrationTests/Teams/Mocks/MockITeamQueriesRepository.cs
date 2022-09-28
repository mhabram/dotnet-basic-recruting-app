using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MatchDataManager.IntegrationTests.Teams.Mocks;

internal class MockITeamQueriesRepository
{
    internal static ITeamQueriesRepository GetTeamRepository()
    {
        var mockTeamQueriesRepository = new Mock<ITeamQueriesRepository>();

        mockTeamQueriesRepository
            .Setup(s =>
                s.GetTeamByIdAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(TeamTestData.Teams.First());

        mockTeamQueriesRepository
            .Setup(s =>
                s.GetTeamsAsync(
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(TeamTestData.Teams);

        return mockTeamQueriesRepository.Object;
    }

    internal static ITeamQueriesRepository GetTeamRepositoryWithNull()
    {
        var mockTeamQueriesRepository = new Mock<ITeamQueriesRepository>();

        mockTeamQueriesRepository
            .Setup(s =>
                s.GetTeamByIdAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()));

        mockTeamQueriesRepository
            .Setup(s =>
                s.GetTeamsAsync(
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Team>());

        return mockTeamQueriesRepository.Object;
    }
}

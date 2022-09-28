using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MatchDataManager.IntegrationTests.Locations.Mocks;

internal class MockILocationQueriesRepository
{
    internal static ILocationQueriesRepository GetLocationRepository()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.GetLocationByIdAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationTestData.Locations.First());

        mockLocationQueriesRepository
            .Setup(s =>
                s.GetLocationsAsync(
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(LocationTestData.Locations);

        return mockLocationQueriesRepository.Object;
    }

    internal static ILocationQueriesRepository GetLocationRepositoryWithNull()
    {
        var mockLocationQueriesRepository = new Mock<ILocationQueriesRepository>();

        mockLocationQueriesRepository
            .Setup(s =>
                s.GetLocationByIdAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()));

        mockLocationQueriesRepository
            .Setup(s =>
                s.GetLocationsAsync(
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Location>());

        return mockLocationQueriesRepository.Object;
    }
}

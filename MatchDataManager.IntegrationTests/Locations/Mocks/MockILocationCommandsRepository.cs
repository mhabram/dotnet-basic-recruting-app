using MatchDataManager.Application.Common.Exceptions.Location;
using MatchDataManager.Application.Common.Exceptions.Repository;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using Moq;
using System;
using System.Threading;

namespace MatchDataManager.IntegrationTests.Locations.Mocks;

internal class MockILocationCommandsRepository
{
    internal static ILocationCommandsRepository GetLocationRepository()
    {
        var mockLocationCommandRepository = new Mock<ILocationCommandsRepository>();

        mockLocationCommandRepository
            .Setup(s =>
                s.CreateLocationAsync(
                    It.IsAny<Location>(),
                    It.IsAny<CancellationToken>()));

        mockLocationCommandRepository
            .Setup(s =>
                s.UpdateLocationAsync(
                    It.IsAny<Location>(),
                    It.IsAny<CancellationToken>()));

        mockLocationCommandRepository
            .Setup(s =>
                s.DeleteLocationAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()));

        return mockLocationCommandRepository.Object;
    }

    internal static ILocationCommandsRepository GetLocationRepositoryWithException()
    {
        var mockLocationCommandRepository = new Mock<ILocationCommandsRepository>();

        mockLocationCommandRepository
            .Setup(s =>
                s.CreateLocationAsync(
                    It.IsAny<Location>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new SaveToDatabaseException());

        mockLocationCommandRepository
            .Setup(s =>
                s.UpdateLocationAsync(
                    It.IsAny<Location>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new LocationNullException());

        mockLocationCommandRepository
            .Setup(s =>
                s.DeleteLocationAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new LocationNullException());

        return mockLocationCommandRepository.Object;
    }
}

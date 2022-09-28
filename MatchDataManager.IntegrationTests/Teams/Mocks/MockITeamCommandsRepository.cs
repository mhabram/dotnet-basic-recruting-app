using MatchDataManager.Application.Common.Exceptions.Repository;
using MatchDataManager.Application.Common.Exceptions.Team;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using Moq;
using System;
using System.Threading;

namespace MatchDataManager.IntegrationTests.Teams.Mocks;

internal class MockITeamCommandsRepository
{
    internal static ITeamCommandsRepository GetTeamRepository()
    {
        var mockTeamCommandRepository = new Mock<ITeamCommandsRepository>();

        mockTeamCommandRepository
            .Setup(s =>
                s.CreateTeamAsync(
                    It.IsAny<Team>(),
                    It.IsAny<CancellationToken>()));

        mockTeamCommandRepository
            .Setup(s =>
                s.UpdateTeamAsync(
                    It.IsAny<Team>(),
                    It.IsAny<CancellationToken>()));

        mockTeamCommandRepository
            .Setup(s =>
                s.DeleteTeamAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()));

        return mockTeamCommandRepository.Object;
    }

    internal static ITeamCommandsRepository GetTeamRepositoryWithException()
    {
        var mockTeamCommandRepository = new Mock<ITeamCommandsRepository>();

        mockTeamCommandRepository
            .Setup(s =>
                s.CreateTeamAsync(
                    It.IsAny<Team>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new SaveToDatabaseException());

        mockTeamCommandRepository
            .Setup(s =>
                s.UpdateTeamAsync(
                    It.IsAny<Team>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new TeamNullException());

        mockTeamCommandRepository
            .Setup(s =>
                s.DeleteTeamAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
            .Throws(new TeamNullException());

        return mockTeamCommandRepository.Object;
    }
}

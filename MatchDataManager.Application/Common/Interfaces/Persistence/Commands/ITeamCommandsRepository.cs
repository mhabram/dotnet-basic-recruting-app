using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Commands;

public interface ITeamCommandsRepository
{
    Task CreateTeamAsync(Team teamEntity, CancellationToken cancellationToken = default);
    Task DeleteTeamAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateTeamAsync(Team team, CancellationToken cancellationToken = default);
}

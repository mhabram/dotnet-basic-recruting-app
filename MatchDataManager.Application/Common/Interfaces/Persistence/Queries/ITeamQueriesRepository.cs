using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

public interface ITeamQueriesRepository
{
    Task<bool> IsUniqueTeamNameAsync(string name, CancellationToken cancellationToken = default);
    Task<Team?> GetTeamByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Team>> GetTeamsAsync(CancellationToken cancellationToken = default);
}

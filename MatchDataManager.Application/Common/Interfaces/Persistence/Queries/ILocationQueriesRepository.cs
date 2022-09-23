using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

public interface ILocationQueriesRepository
{
    Task<Location> GetLocationAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Location>> GetLocationsAsync(CancellationToken cancellationToken = default);
    Task<bool> IsUniqueName(string name);
}

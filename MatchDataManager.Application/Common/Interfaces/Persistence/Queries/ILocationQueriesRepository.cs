using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

public interface ILocationQueriesRepository
{
    Task<Location?> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Location>> GetLocationsAsync(CancellationToken cancellationToken = default);
    Task<bool> IsUniqueLocationNameAsync(string name, CancellationToken cancellationToken = default);
}

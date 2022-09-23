using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Infrastructure.Repositories.Queires;

public class LocationQueriesRepository : ILocationQueriesRepository
{
    public async Task<Location> GetLocationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return LocationsRepository.GetLocationById(id);
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync(CancellationToken cancellationToken = default)
    {
        return LocationsRepository.GetAllLocations();
    }

    public async Task<bool> IsUniqueName(string name)
    {
        return LocationsRepository.GetLocationByName(name);
    }
}

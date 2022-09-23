using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Infrastructure.Repositories.Commands;

public class LocationCommandsRepository : ILocationCommandsRepository
{
    public async Task CreateLocationAsync(Location location, CancellationToken cancellationToken = default)
    {
        LocationsRepository.Add(location);
    }

    public async Task DeleteLocation(Guid id)
    {
        LocationsRepository.DeleteLocation(id);
    }

    public async Task UpdateLocationAsync(Location location)
    {
        LocationsRepository.UpdateLocation(location);
    }
}

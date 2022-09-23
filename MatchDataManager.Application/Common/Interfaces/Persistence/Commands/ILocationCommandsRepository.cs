using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Commands;

public interface ILocationCommandsRepository
{
    Task CreateLocationAsync(Location location, CancellationToken cancellationToken = default);
    Task DeleteLocation(Guid id);
    Task UpdateLocationAsync(Location location);
}

using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Application.Common.Interfaces.Persistence.Commands;

public interface ILocationCommandsRepository
{
    Task CreateLocationAsync(Location location, CancellationToken cancellationToken = default);
    Task DeleteLocation(Guid id, CancellationToken cancellationToken = default);
    Task UpdateLocationAsync(Location location, CancellationToken cancellationToken = default);
}

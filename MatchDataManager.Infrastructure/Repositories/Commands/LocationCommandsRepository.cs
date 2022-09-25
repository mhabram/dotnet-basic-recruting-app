using MatchDataManager.Application.Common.Interfaces.Persistence;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Infrastructure.Repositories.Commands;

public class LocationCommandsRepository : ILocationCommandsRepository
{
    private readonly IApplicationDbContext _context;
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public LocationCommandsRepository(
        IApplicationDbContext context,
        ILocationQueriesRepository locationQueriesRepository)
    {
        _context = context;
        _locationQueriesRepository = locationQueriesRepository;
    }


    public async Task CreateLocationAsync(Location location, CancellationToken cancellationToken = default)
    {
        await _context.Locations
            .AddAsync(location, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLocation(Guid id, CancellationToken cancellationToken = default)
    {
        var locationEntity = await _locationQueriesRepository
            .GetLocationByIdAsync(id, cancellationToken);

        _context.Locations.Remove(locationEntity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateLocationAsync(Location location, CancellationToken cancellationToken = default)
    {
        var locationEntity = await _locationQueriesRepository
            .GetLocationByIdAsync(location.Id, cancellationToken);

        locationEntity.Name = location.Name;
        locationEntity.City = location.City;

        _context.Locations.Update(locationEntity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

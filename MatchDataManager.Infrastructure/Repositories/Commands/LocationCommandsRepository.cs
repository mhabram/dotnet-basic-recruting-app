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
        var existingLocation = await _locationQueriesRepository
            .GetLocationByIdAsync(id, cancellationToken);

        _context.Locations.Remove(existingLocation);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateLocationAsync(Location location, CancellationToken cancellationToken = default)
    {
        var existingLocation = await _locationQueriesRepository
            .GetLocationByIdAsync(location.Id, cancellationToken);

        existingLocation.Name = location.Name;
        existingLocation.City = location.City;

        _context.Locations.Update(existingLocation);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

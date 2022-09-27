using MatchDataManager.Application.Common.Exceptions.Location;
using MatchDataManager.Application.Common.Exceptions.Repository;
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
        try
        {
            await _context.Locations
                .AddAsync(location, cancellationToken);
        
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(CreateLocationAsync), ex);
        }
    }

    public async Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var locationEntity = await _locationQueriesRepository
                .GetLocationByIdAsync(id, cancellationToken);

            if (locationEntity is null)
                throw new LocationNullException(nameof(DeleteLocationAsync));

            _context.Locations.Remove(locationEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (LocationNullException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(CreateLocationAsync), ex);
        }
    }

    public async Task UpdateLocationAsync(Location location, CancellationToken cancellationToken = default)
    {
        try
        {
            var locationEntity = await _locationQueriesRepository
                .GetLocationByIdAsync(location.Id, cancellationToken);

            if (locationEntity is null)
                throw new LocationNullException(nameof(UpdateLocationAsync));

            locationEntity.Name = location.Name;
            locationEntity.City = location.City;

            _context.Locations.Update(locationEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (LocationNullException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(UpdateLocationAsync), ex);
        }
    }
}

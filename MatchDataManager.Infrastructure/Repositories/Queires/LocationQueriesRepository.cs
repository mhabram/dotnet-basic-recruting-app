using MatchDataManager.Application.Common.Interfaces.Persistence;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Infrastructure.Repositories.Queires;

public class LocationQueriesRepository : ILocationQueriesRepository
{
    private readonly IApplicationDbContext _context;

    public LocationQueriesRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Location?> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Locations
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsUniqueLocationNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var locationEntity = await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.Name.Trim().ToLower() == name.Trim().ToLower(),
                cancellationToken);

        return locationEntity == null;
    }
}

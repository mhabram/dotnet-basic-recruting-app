﻿using MatchDataManager.Application.Common.Interfaces.Persistence;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Infrastructure.Repositories.Queires;

public class TeamQueriesRepository : ITeamQueriesRepository
{
    private readonly IApplicationDbContext _context;

    public TeamQueriesRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Team?> GetTeamByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Teams
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Team>> GetTeamsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Teams
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsUniqueTeamNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var teamEntity = await _context.Teams
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.Name.Trim().ToLower() == name.Trim().ToLower(),
                cancellationToken);

        return teamEntity == null;
    }
}

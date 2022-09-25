using MatchDataManager.Application.Common.Interfaces.Persistence;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Infrastructure.Repositories.Commands;

public class TeamCommandsRepository : ITeamCommandsRepository
{
    private readonly IApplicationDbContext _context;
    private readonly ITeamQueriesRepository _teamQueriesRepository;

    public TeamCommandsRepository(
        IApplicationDbContext context,
        ITeamQueriesRepository teamQueriesRepository)
    {
        _context = context;
        _teamQueriesRepository = teamQueriesRepository;
    }

    public async Task CreateTeamAsync(Team teamEntity, CancellationToken cancellationToken = default)
    {
        _context.Teams.Add(teamEntity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTeamAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var teamEntity = await _teamQueriesRepository
            .GetTeamByIdAsync(id, cancellationToken);

        _context.Teams.Remove(teamEntity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        var teamEntity = await _teamQueriesRepository
            .GetTeamByIdAsync(team.Id, cancellationToken);

        teamEntity.Name = team.Name;
        teamEntity.CoachName = team.CoachName;

        await _context.Teams.AddAsync(teamEntity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

using MatchDataManager.Application.Common.Exceptions.Repository;
using MatchDataManager.Application.Common.Exceptions.Team;
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
        try
        {
            _context.Teams.Add(teamEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(CreateTeamAsync), ex);
        }
    }

    public async Task DeleteTeamAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var teamEntity = await _teamQueriesRepository
                .GetTeamByIdAsync(id, cancellationToken);

            if (teamEntity is null)
                throw new TeamNullException(nameof(DeleteTeamAsync));

            _context.Teams.Remove(teamEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (TeamNullException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(DeleteTeamAsync), ex);
        }
    }

    public async Task UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        try
        {
            var teamEntity = await _teamQueriesRepository
                .GetTeamByIdAsync(team.Id, cancellationToken);

            if (teamEntity is null)
                throw new TeamNullException(nameof(UpdateTeamAsync));

            teamEntity.Name = team.Name;
            teamEntity.CoachName = team.CoachName;

            _context.Teams.Update(teamEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (TeamNullException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw new SaveToDatabaseException(nameof(UpdateTeamAsync), ex);
        }
    }
}

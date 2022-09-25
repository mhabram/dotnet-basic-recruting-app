using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Queries.GetTeams;

public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IEnumerable<Team>>
{
    private readonly ITeamQueriesRepository _teamQueriesRepository;

    public GetTeamsQueryHandler(ITeamQueriesRepository teamQueriesRepository)
    {
        _teamQueriesRepository = teamQueriesRepository;
    }

    public async Task<IEnumerable<Team>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        var teamEntities = await _teamQueriesRepository.GetTeamsAsync(cancellationToken);

        return teamEntities;
    }
}

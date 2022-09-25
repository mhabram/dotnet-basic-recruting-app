using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Queries.GetTeamById;

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Team>
{
    private readonly ITeamQueriesRepository _teamQueriesRepository;

    public GetTeamByIdQueryHandler(ITeamQueriesRepository teamQueriesRepository)
    {
        _teamQueriesRepository = teamQueriesRepository;
    }

    public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var teamEntity = await _teamQueriesRepository.GetTeamByIdAsync(request.Id, cancellationToken);

        return teamEntity;
    }
}

using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
{
    private readonly ITeamCommandsRepository _teamCommandsReporitory;

    public UpdateTeamCommandHandler(ITeamCommandsRepository teamCommandsReporitory)
    {
        _teamCommandsReporitory = teamCommandsReporitory;
    }

    public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        await _teamCommandsReporitory
            .UpdateTeamAsync(new Team(
                request.Id,
                request.Name,
                request.CoachName),
                cancellationToken);

        return await Task.FromResult(Unit.Value);
    }
}

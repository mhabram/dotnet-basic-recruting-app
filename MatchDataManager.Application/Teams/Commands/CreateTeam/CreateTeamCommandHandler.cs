using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Team>
{
    private readonly ITeamCommandsRepository _teamCommandsRepository;

    public CreateTeamCommandHandler(ITeamCommandsRepository teamCommandsRepository)
    {
        _teamCommandsRepository = teamCommandsRepository;
    }

    public async Task<Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var teamEntity = new Team(request.Name, request.CoachName);

        await _teamCommandsRepository.CreateTeamAsync(teamEntity, cancellationToken);

        return teamEntity;
    }
}

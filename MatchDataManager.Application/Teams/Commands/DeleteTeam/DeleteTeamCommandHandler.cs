using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MediatR;

namespace MatchDataManager.Application.Teams.Commands.DeleteTeam;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
{
    private readonly ITeamCommandsRepository _teamCommandsRepository;

    public DeleteTeamCommandHandler(ITeamCommandsRepository teamCommandsRepository)
    {
        _teamCommandsRepository = teamCommandsRepository;
    }

    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        await _teamCommandsRepository.DeleteTeamAsync(request.Id, cancellationToken);

        return await Task.FromResult(Unit.Value);
    }
}

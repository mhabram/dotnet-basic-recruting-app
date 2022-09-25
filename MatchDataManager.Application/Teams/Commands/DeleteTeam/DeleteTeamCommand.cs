using MediatR;

namespace MatchDataManager.Application.Teams.Commands.DeleteTeam;

public record DeleteTeamCommand(
    Guid Id)
    : IRequest;
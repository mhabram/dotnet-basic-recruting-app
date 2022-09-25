using MediatR;

namespace MatchDataManager.Application.Teams.Commands.UpdateTeam;

public record UpdateTeamCommand(
    Guid Id,
    string Name,
    string CoachName)
    : IRequest;
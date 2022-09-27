using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Queries.GetTeamById;

public record GetTeamByIdQuery(
    Guid Id)
    : IRequest<Team?>;
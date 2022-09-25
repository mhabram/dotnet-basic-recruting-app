using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Teams.Queries.GetTeams;

public record GetTeamsQuery()
    : IRequest<IEnumerable<Team>>;

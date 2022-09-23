using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocation;

public record GetLocationQuery(
    Guid Id)
    : IRequest<Location>;

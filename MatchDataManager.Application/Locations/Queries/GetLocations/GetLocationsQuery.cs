using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocations;

public record GetLocationsQuery()
    : IRequest<IEnumerable<Location>>;

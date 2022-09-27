using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocationById;

public record GetLocationByIdQuery(
    Guid Id)
    : IRequest<Location?>;

using MediatR;

namespace MatchDataManager.Application.Locations.Commands.UpdateLocation;

public record UpdateLocationCommand(
    Guid Id,
    string Name,
    string City)
    : IRequest;
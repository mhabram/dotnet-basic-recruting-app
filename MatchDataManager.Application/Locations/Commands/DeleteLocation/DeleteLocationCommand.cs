using MediatR;

namespace MatchDataManager.Application.Locations.Commands.DeleteLocation;

public record DeleteLocationCommand(
    Guid Id)
    : IRequest;

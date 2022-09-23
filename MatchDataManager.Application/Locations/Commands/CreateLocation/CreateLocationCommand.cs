using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Commands.CreateLocation;

public record CreateLocationCommand(
    string Name,
    string City)
    : IRequest<Location>;
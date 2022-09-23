using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Location>
{
    private readonly ILocationCommandsRepository _locationCommandsRepository;

    public CreateLocationCommandHandler(ILocationCommandsRepository locationCommandsRepository)
    {
        _locationCommandsRepository = locationCommandsRepository;
    }

    public async Task<Location> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var locationEntity = new Location(request.Name, request.City);

        await _locationCommandsRepository.CreateLocationAsync(locationEntity, cancellationToken);

        return locationEntity;
    }
}

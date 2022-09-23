using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly ILocationCommandsRepository _locationCommandsRepository;

    public UpdateLocationCommandHandler(ILocationCommandsRepository locationCommandsRepository)
    {
        _locationCommandsRepository = locationCommandsRepository;
    }

    public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        await _locationCommandsRepository
            .UpdateLocationAsync(new Location(
                request.Id,
                request.Name,
                request.City));

        return Unit.Value;
    }
}

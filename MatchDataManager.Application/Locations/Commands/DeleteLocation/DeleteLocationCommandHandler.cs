using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MediatR;

namespace MatchDataManager.Application.Locations.Commands.DeleteLocation;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly ILocationCommandsRepository _locationCommandsRepository;

    public DeleteLocationCommandHandler(ILocationCommandsRepository locationCommandsRepository)
    {
        _locationCommandsRepository = locationCommandsRepository;
    }

    public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        await _locationCommandsRepository.DeleteLocation(request.Id);

        return Unit.Value;
    }
}

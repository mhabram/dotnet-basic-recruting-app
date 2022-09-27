using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocationById;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Location?>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public GetLocationByIdQueryHandler(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;
    }

    public async Task<Location?> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var locationsEntity = await _locationQueriesRepository.GetLocationByIdAsync(request.Id, cancellationToken);

        return locationsEntity;
    }
}

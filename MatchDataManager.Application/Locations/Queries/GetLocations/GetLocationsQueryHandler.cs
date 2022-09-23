using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocations;

public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public GetLocationsQueryHandler(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;
    }

    public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var locationEntities = await _locationQueriesRepository.GetLocationsAsync(cancellationToken);

        return locationEntities;
    }
}

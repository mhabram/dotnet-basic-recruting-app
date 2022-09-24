using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Domain.Entities;
using MediatR;

namespace MatchDataManager.Application.Locations.Queries.GetLocation;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Location>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public GetLocationQueryHandler(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;
    }

    public async Task<Location> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var locationsEntity = await _locationQueriesRepository.GetLocationByIdAsync(request.Id, cancellationToken);
        
        return locationsEntity;
    }
}

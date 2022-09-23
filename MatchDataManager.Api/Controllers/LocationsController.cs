using MatchDataManager.Application.Locations.Commands.CreateLocation;
using MatchDataManager.Application.Locations.Commands.DeleteLocation;
using MatchDataManager.Application.Locations.Commands.UpdateLocation;
using MatchDataManager.Application.Locations.Queries.GetLocation;
using MatchDataManager.Application.Locations.Queries.GetLocations;
using MatchDataManager.Contracts.Locations;
using MatchDataManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

public class LocationsController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationRequest request)
    {
        var location = await Mediator.Send(new CreateLocationCommand(
            request.Name,
            request.City));

        return CreatedAtAction(
            nameof(GetLocation),
            new { id = location.Id},
            MapLocationResponse(location));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLocation(Guid id)
    {
        var location = await Mediator.Send(new GetLocationQuery(id));

        return Ok(MapLocationResponse(location));
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await Mediator.Send(new GetLocationsQuery());

        return Ok(MapLocationsResponse(locations));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {
        await Mediator.Send(new DeleteLocationCommand(id));

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateLocation(Guid id, UpdateLocationRequest request)
    {
        await Mediator.Send(new UpdateLocationCommand(
            id,
            request.Name,
            request.City));

        return NoContent();
    }

    private static IEnumerable<LocationResponse> MapLocationsResponse(IEnumerable<Location> locations)
    {
        var locationList = new List<LocationResponse>();

        foreach (var location in locations)
            locationList.Add(new LocationResponse(
                location.Id,
                location.Name,
                location.City));

        return locationList;
    }

    private static LocationResponse MapLocationResponse(Location location)
    {
        return new LocationResponse(
            location.Id,
            location.Name,
            location.City);
    }
}
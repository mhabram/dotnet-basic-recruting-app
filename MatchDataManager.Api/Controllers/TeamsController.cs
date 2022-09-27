using MatchDataManager.Application.Teams.Commands.CreateTeam;
using MatchDataManager.Application.Teams.Commands.DeleteTeam;
using MatchDataManager.Application.Teams.Commands.UpdateTeam;
using MatchDataManager.Application.Teams.Queries.GetTeamById;
using MatchDataManager.Application.Teams.Queries.GetTeams;
using MatchDataManager.Contracts.Teams;
using MatchDataManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

public class TeamsController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTeam(CreateTeamRequest request)
    {
        var team = await Mediator.Send(new CreateTeamCommand(
            request.Name,
            request.CoachName));

        return CreatedAtAction(
            nameof(GetTeamById),
            new { id = team.Id },
            MapTeamResponse(team));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTeamById(Guid id)
    {
        var team = await Mediator.Send(new GetTeamByIdQuery(id));

        return Ok(MapTeamResponse(team));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teams = await Mediator.Send(new GetTeamsQuery());

        return Ok(MapTeamsResponse(teams));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        await Mediator.Send(new DeleteTeamCommand(id));

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTeam(Guid id, UpdateTeamRequest request)
    {
        await Mediator.Send(new UpdateTeamCommand(
            id,
            request.Name,
            request.CoachName));

        return NoContent();
    }

    private static IEnumerable<TeamResponse> MapTeamsResponse(IEnumerable<Team> teamns)
    {
        var teamList = new List<TeamResponse>();

        foreach (var team in teamns)
            teamList.Add(MapTeamResponse(team)!);

        return teamList;
    }

    private static TeamResponse? MapTeamResponse(Team? team)
    {
        if (team is null)
            return null;

        return new TeamResponse(
            team.Id,
            team.Name,
            team.CoachName);
    }
}
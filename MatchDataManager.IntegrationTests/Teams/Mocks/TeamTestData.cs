using MatchDataManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MatchDataManager.IntegrationTests.Teams.Mocks;

public static class TeamTestData
{
    public static readonly List<Team> Teams = new List<Team>()
    {
        new Team(Guid.NewGuid(), "RK Team", "Robert"),
        new Team(Guid.NewGuid(), "GL Team", "Karol"),
    };
}

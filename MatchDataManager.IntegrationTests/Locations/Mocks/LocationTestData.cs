using MatchDataManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MatchDataManager.IntegrationTests.Locations.Mocks;

public static class LocationTestData
{
    public static readonly List<Location> Locations = new List<Location>()
    {
        new Location(Guid.NewGuid(), "RK", "Rybnik"),
        new Location(Guid.NewGuid(), "GL", "Gliwice")

    };
}

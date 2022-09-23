using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Locations.Commands.UpdateLocation;
using MatchDataManager.UnitTests.Locations.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace MatchDataManager.UnitTests.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandTests
{
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameTrue;
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameFalse;

    public UpdateLocationCommandTests()
    {
        _locationQueriesRepositoryUniqueNameTrue = MockILocationQueriesRepository.GetLocationUniqueNameTrue();
        _locationQueriesRepositoryUniqueNameFalse = MockILocationQueriesRepository.GetLocationUniqueNameFalse();
    }

    [Theory]
    [MemberData(nameof(UpdateLocationCommandTestData))]
    public void UpdateLocationCommandValidatorShouldThrowFieldIsRequired(UpdateLocationCommand locationCommand, string expected)
    {
        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals(expected);
    }

    [Fact]
    public void UpdateLocationCommandValidatorShouldThrowUniqueNameIsRequired()
    {
        var locationCommand = new UpdateLocationCommand(Guid.NewGuid(), "GL", "Gliwice");

        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameFalse);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Unique name is required.");
    }

    [Fact]
    public void UpdateLocationCommandValidatorShouldThrowTooLongName()
    {
        var locationCommand = new UpdateLocationCommand(
            Guid.NewGuid(),
            "zUKYZ8Su4b3vKnGEQ6mb4tRx256Q7hxhR928uOMJgmRox10b6832KuUhkTkiGPwOZCj1ejIceHwVrAts4Dr3LZEDlnZ758aqLOG7TIAtkbepjyCQlXHrO5XoybvB9LkEVd3k68fs6Cv2G03EulFCcDABWLkRDswPufm0MGtClgDeodbET1Bdp7iQzSmkeenGcejQNHXJTVbT2xSiOq8ulXK6aNuBf3qfn3DYISriexy7FI9EH2AINHA5dAAZy9Pw",
            "Rybnik");

        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Length can't be longer than 255.");
    }

    [Fact]
    public void UpdateLocationCommandValidatorShouldThrowTooLongCity()
    {
        var locationCommand = new UpdateLocationCommand(
            Guid.NewGuid(),
            "RK",
            "Tow6ND1GDubUKI73Uu2JATBfGgkwIAUs3FwSmkbPZ9qlkGq0xN7hE6JJ");

        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Length can't be longer than 55.");
    }

    public static IEnumerable<object[]> UpdateLocationCommandTestData()
    {
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), " ", "Gliwice"), "Name field is required." };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "", "Rybnik"), "Name field is required." };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), null, "Katowice"), "Name field is required." };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "GL", ""), "City field is required." };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "RK", null), "City field is required." };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "KRK", " "), "City field is required." };
    }
}

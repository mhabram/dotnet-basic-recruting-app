using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Locations.Commands.CreateLocation;
using MatchDataManager.UnitTests.Locations.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MatchDataManager.UnitTests.Locations.Commands.CreateLocation;

public class CreateLocationCommandTests
{
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameTrue;
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameFalse;

    public CreateLocationCommandTests()
    {
        _locationQueriesRepositoryUniqueNameTrue = MockILocationQueriesRepository.GetLocationUniqueNameTrue();
        _locationQueriesRepositoryUniqueNameFalse = MockILocationQueriesRepository.GetLocationUniqueNameFalse();
    }

    [Theory]
    [MemberData(nameof(CreateLocationCommandTestData))]
    public void CreateLocationCommandValidatorShouldThrowFieldIsRequired(CreateLocationCommand locationCommand, string expected)
    {
        var validator = new CreateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals(expected);
    }

    [Fact]
    public void CreateLocationCommandValidatorShouldThrowUniqueNameIsRequired()
    {
        var locationCommand = new CreateLocationCommand("GL", "Gliwice");

        var validator = new CreateLocationCommandValidator(_locationQueriesRepositoryUniqueNameFalse);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Unique name is required.");
    }

    [Fact]
    public void CreateLocationCommandValidatorShouldThrowTooLongName()
    {
        var locationCommand = new CreateLocationCommand(
            "zUKYZ8Su4b3vKnGEQ6mb4tRx256Q7hxhR928uOMJgmRox10b6832KuUhkTkiGPwOZCj1ejIceHwVrAts4Dr3LZEDlnZ758aqLOG7TIAtkbepjyCQlXHrO5XoybvB9LkEVd3k68fs6Cv2G03EulFCcDABWLkRDswPufm0MGtClgDeodbET1Bdp7iQzSmkeenGcejQNHXJTVbT2xSiOq8ulXK6aNuBf3qfn3DYISriexy7FI9EH2AINHA5dAAZy9Pw",
            "Rybnik");
        var validator = new CreateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Length can't be longer than 255.");
    }

    [Fact]
    public void CreateLocationCommandValidatorShouldThrowTooLongCity()
    {
        var locationCommand = new CreateLocationCommand(
            "RK",
            "Tow6ND1GDubUKI73Uu2JATBfGgkwIAUs3FwSmkbPZ9qlkGq0xN7hE6JJ");
        var validator = new CreateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        result.Equals("Length can't be longer than 55.");
    }

    public static IEnumerable<object[]> CreateLocationCommandTestData()
    {
        yield return new object[] { new CreateLocationCommand(" ", "Gliwice"), "Name field is required." };
        yield return new object[] { new CreateLocationCommand("", "Rybnik"), "Name field is required." };
        yield return new object[] { new CreateLocationCommand(null, "Katowice"), "Name field is required." };
        yield return new object[] { new CreateLocationCommand("GL", ""), "City field is required." };
        yield return new object[] { new CreateLocationCommand("RK", null), "City field is required." };
        yield return new object[] { new CreateLocationCommand("KRK", " "), "City field is required." };
    }

}

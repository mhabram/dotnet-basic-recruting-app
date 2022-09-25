using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Teams.Commands.UpdateTeam;
using MatchDataManager.UnitTests.Teams.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace MatchDataManager.UnitTests.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandTests
{
    private readonly ITeamQueriesRepository _teamQueriesRepositoryUniqueNameTrue;
    private readonly ITeamQueriesRepository _teamQueriesRepositoryUniqueNameFalse;

    public UpdateTeamCommandTests()
    {
        _teamQueriesRepositoryUniqueNameTrue = MockITeamQueriesRepository.GetTeamUniqueName(true);
        _teamQueriesRepositoryUniqueNameFalse = MockITeamQueriesRepository.GetTeamUniqueName(false);
    }

    [Theory]
    [MemberData(nameof(UpdateTeamCommandTestData))]
    public void UpdateTeamCommandValidatorShouldThrowFieldIsRequired(UpdateTeamCommand teamCommand, string expected)
    {
        var validator = new UpdateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals(expected);
    }


    [Fact]
    public void UpdateTeamCommandValidatorShouldThrowUniqueNameIsRequired()
    {
        var teamCommand = new UpdateTeamCommand(Guid.NewGuid(), "GL Team", "Karol");

        var validator = new UpdateTeamCommandValidator(_teamQueriesRepositoryUniqueNameFalse);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals("Unique name is required.");
    }

    [Fact]
    public void UpdateTeamCommandValidatorShouldThrowTooLongName()
    {
        var teamCommand = new UpdateTeamCommand(
            Guid.NewGuid(),
            "zUKYZ8Su4b3vKnGEQ6mb4tRx256Q7hxhR928uOMJgmRox10b6832KuUhkTkiGPwOZCj1ejIceHwVrAts4Dr3LZEDlnZ758aqLOG7TIAtkbepjyCQlXHrO5XoybvB9LkEVd3k68fs6Cv2G03EulFCcDABWLkRDswPufm0MGtClgDeodbET1Bdp7iQzSmkeenGcejQNHXJTVbT2xSiOq8ulXK6aNuBf3qfn3DYISriexy7FI9EH2AINHA5dAAZy9Pw",
            "Karol");
        var validator = new UpdateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals("Length can't be longer than 255.");
    }

    [Fact]
    public void UpdateTeamCommandValidatorShouldThrowTooLongCoachName()
    {
        var teamCommand = new UpdateTeamCommand(
            Guid.NewGuid(),
            "GL",
            "Tow6ND1GDubUKI73Uu2JATBfGgkwIAUs3FwSmkbPZ9qlkGq0xN7hE6JJ");
        var validator = new UpdateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals("Length can't be longer than 55.");
    }

    public static IEnumerable<object[]> UpdateTeamCommandTestData()
    {
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), "", "Karol"), "Name field is required." };
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), " ", "Dawid"), "Name field is required." };
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), null, "Patryk"), "Name field is required." };
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), "GL Team", ""), "Coach name field is required." };
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), "RK Team", " "), "Coach name field is required." };
        yield return new object[] { new UpdateTeamCommand(Guid.NewGuid(), "KRK Team", null), "Coach name field is required." };
    }
}

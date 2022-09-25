using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Teams.Commands.CreateTeam;
using MatchDataManager.UnitTests.Teams.Mocks;
using System.Collections.Generic;
using Xunit;
using static MatchDataManager.Domain.Common.Constants.ErrorMessages;

namespace MatchDataManager.UnitTests.Teams.Commands.CreateTeam;

public class CreateTeamCommandTests
{
    private readonly ITeamQueriesRepository _teamQueriesRepositoryUniqueNameTrue;
    private readonly ITeamQueriesRepository _teamQueriesRepositoryUniqueNameFalse;

    public CreateTeamCommandTests()
    {
        _teamQueriesRepositoryUniqueNameTrue = MockITeamQueriesRepository.GetTeamUniqueName(true);
        _teamQueriesRepositoryUniqueNameFalse = MockITeamQueriesRepository.GetTeamUniqueName(false);
    }

    [Theory]
    [MemberData(nameof(CreateTeamCommandTestData))]
    public void CreateTeamCommandValidatorShouldThrowFieldIsRequired(CreateTeamCommand teamCommand, string expected)
    {
        var validator = new CreateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals(expected);
    }


    [Fact]
    public void CreateTeamCommandValidatorShouldThrowUniqueNameIsRequired()
    {
        var teamCommand = new CreateTeamCommand("GL Team", "Karol");

        var validator = new CreateTeamCommandValidator(_teamQueriesRepositoryUniqueNameFalse);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals(Name.NotEmpty);
    }

    [Fact]
    public void CreateTeamCommandValidatorShouldThrowTooLongName()
    {
        var teamCommand = new CreateTeamCommand(
            "zUKYZ8Su4b3vKnGEQ6mb4tRx256Q7hxhR928uOMJgmRox10b6832KuUhkTkiGPwOZCj1ejIceHwVrAts4Dr3LZEDlnZ758aqLOG7TIAtkbepjyCQlXHrO5XoybvB9LkEVd3k68fs6Cv2G03EulFCcDABWLkRDswPufm0MGtClgDeodbET1Bdp7iQzSmkeenGcejQNHXJTVbT2xSiOq8ulXK6aNuBf3qfn3DYISriexy7FI9EH2AINHA5dAAZy9Pw",
            "Karol");
        var validator = new CreateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals(Name.MaximumLength);
    }

    [Fact]
    public void CreateTeamCommandValidatorShouldThrowTooLongCoachName()
    {
        var teamCommand = new CreateTeamCommand(
            "GL",
            "Tow6ND1GDubUKI73Uu2JATBfGgkwIAUs3FwSmkbPZ9qlkGq0xN7hE6JJ");
        var validator = new CreateTeamCommandValidator(_teamQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(teamCommand);

        result.Equals(CoachName.MaximumLength);
    }

    public static IEnumerable<object[]> CreateTeamCommandTestData()
    {
        yield return new object[] { new CreateTeamCommand("", "Karol"), Name.NotEmpty };
        yield return new object[] { new CreateTeamCommand(" ", "Dawid"), Name.NotEmpty };
        yield return new object[] { new CreateTeamCommand(null, "Patryk"), Name.NotEmpty };
        yield return new object[] { new CreateTeamCommand("GL Team", ""), CoachName.NotEmpty };
        yield return new object[] { new CreateTeamCommand("RK Team", " "), CoachName.NotEmpty };
        yield return new object[] { new CreateTeamCommand("KRK Team", null), CoachName.NotEmpty };
    }
}

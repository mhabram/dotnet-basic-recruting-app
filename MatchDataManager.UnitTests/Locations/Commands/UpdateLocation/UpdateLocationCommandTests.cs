using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Application.Locations.Commands.UpdateLocation;
using MatchDataManager.UnitTests.Locations.Mocks;
using System;
using System.Collections.Generic;
using Xunit;
using static MatchDataManager.Domain.Common.Constants.ErrorMessages;

namespace MatchDataManager.UnitTests.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandTests
{
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameTrue;
    private readonly ILocationQueriesRepository _locationQueriesRepositoryUniqueNameFalse;

    public UpdateLocationCommandTests()
    {
        _locationQueriesRepositoryUniqueNameTrue = MockILocationQueriesRepository.GetLocationUniqueName(true);
        _locationQueriesRepositoryUniqueNameFalse = MockILocationQueriesRepository.GetLocationUniqueName(false);
    }

    [Theory]
    [MemberData(nameof(UpdateLocationCommandTestData))]
    public void UpdateLocationCommandValidatorShouldThrowFieldIsRequired(UpdateLocationCommand locationCommand, string expected)
    {
        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameTrue);

        var result = validator.ValidateAsync(locationCommand);

        foreach (var error in result.Result.Errors)
            Assert.Equal(expected, error.ErrorMessage);
    }

    [Fact]
    public void UpdateLocationCommandValidatorShouldThrowUniqueNameIsRequired()
    {
        var locationCommand = new UpdateLocationCommand(Guid.NewGuid(), "GL", "Gliwice");

        var validator = new UpdateLocationCommandValidator(_locationQueriesRepositoryUniqueNameFalse);

        var result = validator.ValidateAsync(locationCommand);

        foreach (var error in result.Result.Errors)
            Assert.Equal(Name.IsUnique, error.ErrorMessage);
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

        foreach (var error in result.Result.Errors)
            Assert.Equal(Name.MaximumLength, error.ErrorMessage);
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

        foreach (var error in result.Result.Errors)
            Assert.Equal(City.MaximumLength, error.ErrorMessage);
    }

    public static IEnumerable<object[]> UpdateLocationCommandTestData()
    {
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), " ", "Gliwice"), Name.NotEmpty };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "", "Rybnik"), Name.NotEmpty };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), null, "Katowice"), Name.NotEmpty };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "GL", ""), City.NotEmpty };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "RK", null), City.NotEmpty };
        yield return new object[] { new UpdateLocationCommand(Guid.NewGuid(), "KRK", " "), City.NotEmpty };
    }
}

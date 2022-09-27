using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using static MatchDataManager.Domain.Common.Constants.ErrorMessages;

namespace MatchDataManager.Application.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    private readonly ITeamQueriesRepository _teamQueriesReporitory;

    public UpdateTeamCommandValidator(ITeamQueriesRepository teamQueriesReporitory)
    {
        _teamQueriesReporitory = teamQueriesReporitory;

        RuleFor(t => t.Id)
            .NotEmpty().WithMessage(Id.NotEmpty);

        RuleFor(t => t.Name)
            .NotEmpty().WithMessage(Name.NotEmpty)
            .MaximumLength(255).WithMessage(Name.MaximumLength)
            .MustAsync(IsUniqueName).WithMessage(Name.IsUnique);

        RuleFor(t => t.CoachName)
            .NotEmpty().WithMessage(CoachName.NotEmpty)
            .MaximumLength(55).WithMessage(CoachName.MaximumLength);
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        var test = await _teamQueriesReporitory.IsUniqueTeamNameAsync(name, cancellationToken);
        return await _teamQueriesReporitory.IsUniqueTeamNameAsync(name, cancellationToken);
    }
}

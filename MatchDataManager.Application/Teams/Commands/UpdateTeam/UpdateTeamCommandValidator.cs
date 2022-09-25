using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

namespace MatchDataManager.Application.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    private readonly ITeamQueriesRepository _teamQueriesReporitory;

    public UpdateTeamCommandValidator(ITeamQueriesRepository teamQueriesReporitory)
    {
        _teamQueriesReporitory = teamQueriesReporitory;

        RuleFor(t => t.Id)
            .NotEmpty();

        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(255).WithMessage("Length can't be longer than 255.")
            .MustAsync(IsUniqueName).WithMessage("Unique name is required.");

        RuleFor(t => t.CoachName)
            .NotEmpty().WithMessage("Coach name field is required.")
            .MaximumLength(55).WithMessage("Length can't be longer than 255.");
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _teamQueriesReporitory.IsUniqueTeamNameAsync(name, cancellationToken);
    }
}

using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

namespace MatchDataManager.Application.Teams.Commands.CreateTeam;

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    private readonly ITeamQueriesRepository _teamQueriesRepository;

    public CreateTeamCommandValidator(ITeamQueriesRepository teamQueriesRepository)
    {
        _teamQueriesRepository = teamQueriesRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(255).WithMessage("Length can't be longer than 255.")
            .MustAsync(IsUniqueName).WithMessage("Unique name is required.");

        RuleFor(x => x.CoachName)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(55).WithMessage("Length can't be longer than 55.");
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _teamQueriesRepository.IsUniqueTeamNameAsync(name, cancellationToken);
    }
}

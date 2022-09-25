using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using static MatchDataManager.Domain.Common.Constants.ErrorMessages;

namespace MatchDataManager.Application.Teams.Commands.CreateTeam;

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    private readonly ITeamQueriesRepository _teamQueriesRepository;

    public CreateTeamCommandValidator(ITeamQueriesRepository teamQueriesRepository)
    {
        _teamQueriesRepository = teamQueriesRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Name.NotEmpty)
            .MaximumLength(255).WithMessage(Name.MaximumLength)
            .MustAsync(IsUniqueName).WithMessage(Name.IsUnique);

        RuleFor(x => x.CoachName)
            .NotEmpty().WithMessage(CoachName.NotEmpty)
            .MaximumLength(55).WithMessage(CoachName.MaximumLength);
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _teamQueriesRepository.IsUniqueTeamNameAsync(name, cancellationToken);
    }
}

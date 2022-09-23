using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

namespace MatchDataManager.Application.Locations.Commands.CreateLocation;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public CreateLocationCommandValidator(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(255).WithMessage("Length can't be longer than 255.")
            .MustAsync(IsUniqueName).WithMessage("Unique name is required.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City field is required.")
            .MaximumLength(55).WithMessage("Length can't be longer than 55.");
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken arg2)
    {
        return await _locationQueriesRepository.IsUniqueName(name);
    }
}

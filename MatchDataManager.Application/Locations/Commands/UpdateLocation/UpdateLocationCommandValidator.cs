using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;

namespace MatchDataManager.Application.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public UpdateLocationCommandValidator(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;

        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(255)
            .MustAsync(IsUniqueName);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(55);
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken arg2)
    {
        return await _locationQueriesRepository.IsUniqueName(name);
    }
}

using FluentValidation;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using static MatchDataManager.Domain.Common.Constants.ErrorMessages;

namespace MatchDataManager.Application.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    private readonly ILocationQueriesRepository _locationQueriesRepository;

    public UpdateLocationCommandValidator(ILocationQueriesRepository locationQueriesRepository)
    {
        _locationQueriesRepository = locationQueriesRepository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(Id.NotEmpty);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Name.NotEmpty)
            .MaximumLength(255).WithMessage(Name.MaximumLength)
            .MustAsync(IsUniqueName).WithMessage(Name.IsUnique);

        RuleFor(x => x.City)
            .NotEmpty().WithMessage(City.NotEmpty)
            .MaximumLength(55).WithMessage(City.MaximumLength);
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _locationQueriesRepository.IsUniqueLocationNameAsync(name, cancellationToken);
    }
}

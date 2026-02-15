using FluentValidation;
using Restaurant.Application.Queries;

namespace Restaurant.Application.Validators;

public class GetMenuByRestaurantIdQueryValidator : AbstractValidator<GetMenuByRestaurantIdQuery>
{
    public GetMenuByRestaurantIdQueryValidator()
    {
        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}

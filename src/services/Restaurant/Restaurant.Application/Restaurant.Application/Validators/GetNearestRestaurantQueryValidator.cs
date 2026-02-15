using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Restaurant.Application.Queries;

namespace Restaurant.Application.Validators;

public class GetNearestRestaurantQueryValidator : AbstractValidator<GetNearestRestaurantQuery>
{
    public GetNearestRestaurantQueryValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty();
    }
}

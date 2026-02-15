using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Common.ApplicationBuildingBlocks;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation errors occurred")
    {
        Errors = errors;
    }

    public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
        : this(failures
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()))
    {
    }
}

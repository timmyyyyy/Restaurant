using System;
using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant;

public sealed record WorkingHours : ValueObject
{
    public TimeOnly Start { get; init; }

    public TimeOnly End { get; init; }
}

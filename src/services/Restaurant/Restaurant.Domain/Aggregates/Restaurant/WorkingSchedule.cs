using System;
using System.Collections.Generic;
using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant;

public sealed record WorkingSchedule : ValueObject
{
    public required IDictionary<DayOfWeek, WorkingHours> Schedule { get; init; }
}

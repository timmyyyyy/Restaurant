using System;
using System.Collections.Generic;
using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Restaurant;

public sealed class Restaurant : AggregateRoot
{
    internal Restaurant() : base() { }

    public required IEnumerable<Guid> MenuIds { get; init; }

    public required string Name { get; init; }

    public required Address Address { get; init; }

    public required WorkingSchedule WorkingSchedule { get; init; }
}

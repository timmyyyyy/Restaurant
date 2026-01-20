using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

public sealed record MenuItemSpecificDatesAvailability : MenuItemAvailability
{
    internal MenuItemSpecificDatesAvailability() { }

    public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.SpecificDates;

    public required List<DateOnly> SpecificDates { get; init; }

    public override bool IsCurrentlyAvailable() => SpecificDates.Contains(DateOnly.FromDateTime(DateTime.UtcNow));
}

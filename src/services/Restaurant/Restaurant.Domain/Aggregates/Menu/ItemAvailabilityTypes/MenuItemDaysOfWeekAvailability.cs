using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

public sealed record MenuItemDaysOfWeekAvailability : MenuItemAvailability
{
    [JsonConstructor]
    internal MenuItemDaysOfWeekAvailability() { }

    public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.DaysOfTheWeek;

    public required List<DayOfWeek> DaysOfWeek { get; init; }

    public override bool IsCurrentlyAvailable() => DaysOfWeek.Contains(DateTime.UtcNow.DayOfWeek);
}

using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public sealed class MenuItemSpecificDatesAvailability : MenuItemAvailability
    {
        internal MenuItemSpecificDatesAvailability() { }

        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.SpecificDates;

        public List<DateOnly> SpecificDates { get; init; }

        public override bool IsCurrentlyAvailable() => SpecificDates.Contains(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}

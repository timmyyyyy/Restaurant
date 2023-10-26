using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public class MenuItemSpecificDatesAvailability : MenuItemAvailability
    {
        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.SpecificDates;

        public List<DateOnly> SpecificDates { get; set; }

        public override bool IsCurrentlyAvailable() => SpecificDates.Contains(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}

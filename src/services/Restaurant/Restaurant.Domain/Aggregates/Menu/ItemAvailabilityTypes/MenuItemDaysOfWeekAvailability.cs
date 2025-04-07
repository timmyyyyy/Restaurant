using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public sealed class MenuItemDaysOfWeekAvailability : MenuItemAvailability
    {
        internal MenuItemDaysOfWeekAvailability() { }

        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.DaysOfTheWeek;

        public List<DayOfWeek> DaysOfWeek { get; init; }

        public override bool IsCurrentlyAvailable() => DaysOfWeek.Contains(DateTime.UtcNow.DayOfWeek);
    }
}

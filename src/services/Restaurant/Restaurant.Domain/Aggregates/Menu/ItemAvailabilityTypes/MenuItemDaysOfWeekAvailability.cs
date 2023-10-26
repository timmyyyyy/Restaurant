using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public class MenuItemDaysOfWeekAvailability : MenuItemAvailability
    {
        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.DaysOfTheWeek;

        public List<DayOfWeek> DaysOfWeek { get; set; }

        public override bool IsCurrentlyAvailable() => DaysOfWeek.Contains(DateTime.UtcNow.DayOfWeek);
    }
}

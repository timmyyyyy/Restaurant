using System;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public class MenuItemHoursOfDayAvailability : MenuItemAvailability
    {
        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.HoursOfTheDay;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public override bool IsCurrentlyAvailable()
        {
            var now = TimeOnly.FromDateTime(DateTime.UtcNow);

            return now.IsBetween(StartTime, EndTime);
        }
    }
}

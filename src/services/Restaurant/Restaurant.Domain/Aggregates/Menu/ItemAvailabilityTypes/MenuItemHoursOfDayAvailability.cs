using System;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public sealed class MenuItemHoursOfDayAvailability : MenuItemAvailability
    {
        internal MenuItemHoursOfDayAvailability() { }

        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.HoursOfTheDay;

        public TimeOnly StartTime { get; init; }

        public TimeOnly EndTime { get; init; }

        public override bool IsCurrentlyAvailable()
        {
            var now = TimeOnly.FromDateTime(DateTime.UtcNow);

            return now.IsBetween(StartTime, EndTime);
        }
    }
}

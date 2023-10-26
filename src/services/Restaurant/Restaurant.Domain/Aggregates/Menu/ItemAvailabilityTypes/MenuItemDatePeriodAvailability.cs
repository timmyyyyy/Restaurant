using System;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public class MenuItemDatePeriodAvailability : MenuItemAvailability
    {
        public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.DatePeriod;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public override bool IsCurrentlyAvailable()
        {
            var now = DateTime.UtcNow;

            return now >= StartDate && now <= EndDate;
        }
    }
}

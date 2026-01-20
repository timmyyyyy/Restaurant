using System;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

public sealed record MenuItemDatePeriodAvailability : MenuItemAvailability
{
    internal MenuItemDatePeriodAvailability() { }

    public override MenuItemAvailabilityType MenuItemAvailabilityType => MenuItemAvailabilityType.DatePeriod;

    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }

    public override bool IsCurrentlyAvailable()
    {
        var now = DateTime.UtcNow;

        return now >= StartDate && now <= EndDate;
    }
}

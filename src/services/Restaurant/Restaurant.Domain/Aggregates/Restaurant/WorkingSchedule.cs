using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public sealed class WorkingSchedule : ValueObject
    {
        public IDictionary<DayOfWeek, WorkingHours> Schedule { get; init; }
    }
}

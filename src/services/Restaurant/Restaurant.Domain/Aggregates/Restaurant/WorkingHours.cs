using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public sealed class WorkingHours : ValueObject
    {
        public TimeOnly Start { get; init; }

        public TimeOnly End { get; init; }
    }
}

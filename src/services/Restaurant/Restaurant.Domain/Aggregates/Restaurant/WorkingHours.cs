using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public class WorkingHours : ValueObject
    {
        public TimeOnly Start { get; set; }

        public TimeOnly End { get; set; }
    }
}

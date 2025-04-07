using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public sealed class Restaurant : AggregateRoot
    {
        public IEnumerable<Guid> MenuIds { get; init; }

        public string Name { get; init; }

        public Address Address { get; init; }

        public WorkingSchedule WorkingSchedule { get; init; }
    }
}

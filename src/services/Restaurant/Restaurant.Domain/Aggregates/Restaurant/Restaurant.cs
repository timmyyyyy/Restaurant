using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Aggregates.Restaurant
{
    public class Restaurant : AggregateRoot
    {
        public IEnumerable<int> MenuIds { get; private set; }

        public string Name { get; private set; }

        public Address Address { get; private set; }

        public WorkingSchedule WorkingSchedule { get; private set; }
    }
}

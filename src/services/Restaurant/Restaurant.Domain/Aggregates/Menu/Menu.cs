using Restaurant.Common.DomainBuildingBlocks;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu
{
    public class Menu : AggregateRoot
    {
        public string Name { get; private set; }

        public IEnumerable<MenuItem> Items { get; private set; }
    }
}

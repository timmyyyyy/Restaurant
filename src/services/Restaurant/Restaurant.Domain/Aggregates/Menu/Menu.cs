using Restaurant.Common.DomainBuildingBlocks;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu
{
    public class Menu : AggregateRoot
    {
        public IEnumerable<MenuItem> Items { get; private set; }
    }
}

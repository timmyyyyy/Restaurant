using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Domain.Aggregates.Menu
{
    public sealed class MenuItem : ValueObject
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public MenuItemCategory ItemCategory { get; init; }

        public int? Grammage { get; init; }

        public decimal Price { get; init; }

        public IEnumerable<MenuItemAvailability> Availability { get; init; }

        public bool IsCurrentlyDisabled { get; init; }

        public bool IsAvailable()
        {
            var results = new List<bool>();

            foreach (var item in Availability)
            {
                var result = item.IsCurrentlyAvailable();
                results.Add(result);
            }

            return results.All(x => x == true) && !IsCurrentlyDisabled;
        }
    }
}

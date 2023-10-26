using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Domain.Aggregates.Menu
{
    public class MenuItem : ValueObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MenuItemCategory ItemCategory { get; set; }

        public int? Grammage { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<MenuItemAvailability> Availability { get; set; }

        public bool IsCurrentlyDisabled { get; set; }

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

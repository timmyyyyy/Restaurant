using System.Collections.Generic;
using System.Linq;
using Restaurant.Common.DomainBuildingBlocks;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

namespace Restaurant.Domain.Aggregates.Menu;

public sealed record MenuItem : ValueObject
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required MenuItemCategory ItemCategory { get; init; }

    public int? Grammage { get; init; }

    public decimal Price { get; init; }

    public required IEnumerable<MenuItemAvailability> Availability { get; init; }

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

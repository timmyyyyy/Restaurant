using System;
using System.Collections.Generic;
using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu;

public sealed class Menu : AggregateRoot
{
    internal Menu() : base() { }

    public required string Name { get; init; }

    public required IEnumerable<MenuItem> Items { get; init; }

    public Guid RestaurantId { get; init; }

    public static Menu Create(string name, IEnumerable<MenuItem> items)
    {
        // TODO validation?

        return new()
        {
            Name = name,
            Items = items
        };
    }
}

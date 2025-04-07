using MassTransit;
using Restaurant.Common.DomainBuildingBlocks;
using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Aggregates.Menu
{
    public sealed class Menu : AggregateRoot
    {
        internal Menu() { }

        internal Menu(string name, IEnumerable<MenuItem> items) : base()
        {
            Name = name;
            Items = items;
        }

        public string Name { get; init; }

        public IEnumerable<MenuItem> Items { get; init; }

        public Guid RestaurantId { get; init; }

        public static Menu Create(string name, IEnumerable<MenuItem> items)
        {
            // TODO validation?

            return new Menu(name, items);
        }
    }
}

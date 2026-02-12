using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu;

public sealed class MenuItemCategory : Entity
{
    internal MenuItemCategory() { }

    public required string CategoryName { get; init; }
}

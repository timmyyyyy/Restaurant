using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu;

public sealed record MenuItemCategory : ValueObject
{
    public required string CategoryName { get; init; }
}

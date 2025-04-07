using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu
{
    public sealed class MenuItemCategory : ValueObject
    {
        public string CategoryName { get; init; }
    }
}

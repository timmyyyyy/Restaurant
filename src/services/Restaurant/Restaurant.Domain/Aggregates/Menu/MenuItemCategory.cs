using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu
{
    public class MenuItemCategory : ValueObject
    {
        public string CategoryName { get; set; }
    }
}

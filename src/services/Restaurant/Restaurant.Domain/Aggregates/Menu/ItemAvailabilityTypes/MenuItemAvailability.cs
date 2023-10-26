using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public abstract class MenuItemAvailability : ValueObject
    {
        public abstract MenuItemAvailabilityType MenuItemAvailabilityType { get; }

        public abstract bool IsCurrentlyAvailable();
    }
}

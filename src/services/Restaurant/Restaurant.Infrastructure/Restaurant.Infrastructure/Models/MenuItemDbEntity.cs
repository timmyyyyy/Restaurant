using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

namespace Restaurant.Infrastructure.Models
{
    public class MenuItemDbEntity : BaseDbEntitySoftDeletable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MenuItemCategoryDbEntity ItemCategory { get; set; }

        public int? Grammage { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<MenuItemAvailabilityDbEntity> Availability { get; set; }

        public bool IsCurrentlyDisabled { get; set; }

        public static explicit operator MenuItem(MenuItemDbEntity entity)
            => new()
            {
                Name = entity.Name,
                Description = entity.Description,
                IsCurrentlyDisabled = entity.IsCurrentlyDisabled,
                Availability = entity.Availability.Select(x => (MenuItemAvailability)x),
                Grammage = entity.Grammage,
                Price = entity.Price,
                ItemCategory = (MenuItemCategory)entity.ItemCategory
            };
    }
}

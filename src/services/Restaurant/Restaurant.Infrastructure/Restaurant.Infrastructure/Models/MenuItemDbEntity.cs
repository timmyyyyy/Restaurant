using Restaurant.Common.InfrastructureBuildingBlocks.Persistence;
using Restaurant.Domain.Aggregates.Menu;
using Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

namespace Restaurant.Infrastructure.Models;

public class MenuItemDbEntity : BaseDbEntitySoftDeletable
{
    internal MenuItemDbEntity() { }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required MenuItemCategoryDbEntity ItemCategory { get; set; }

    public int? Grammage { get; set; }

    public decimal Price { get; set; }

    public required IEnumerable<MenuItemAvailabilityDbEntity> Availability { get; set; }

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
